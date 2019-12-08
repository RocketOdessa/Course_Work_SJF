using Model.Process;
using Model.TaskScheduler.Scheduler;
using Model.Utility;
using Model.Utility.Priority;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_UI
{
    public partial class Form1 : Form
    {
        List<ProcessDomain> processes = new List<ProcessDomain>
            {
                new ProcessDomain { ProcessName = "p0", ProcessID = 4, State = ProcessState.Running, Priority = ProcessPriority.Normal },
                new ProcessDomain { ProcessName = "p1", ProcessID = 5, State = ProcessState.Completed, Priority = ProcessPriority.Normal },
                new ProcessDomain { ProcessName = "p2", ProcessID = 6, State = ProcessState.Completed, Priority = ProcessPriority.Normal },
                new ProcessDomain { ProcessName = "p3", ProcessID = 7, State = ProcessState.Completed, Priority = ProcessPriority.Normal },
                new ProcessDomain { ProcessName = "p4", ProcessID = 8, State = ProcessState.New, Priority = ProcessPriority.Normal }
            };

        SJFScheduler sjf;
        static Stopwatch stopwatch = new Stopwatch();
        CancellationTokenSource Source = new CancellationTokenSource();
        readonly CancellationToken Cancellation;

        public Form1()
        {
            InitializeComponent();
            SetAllProcessToLaunch(processes);
            sjf = new SJFScheduler();
            Cancellation = Source.Token;
        }

        private async void static_Init_Click(object sender, EventArgs e)
        {
            begin_Init.Enabled = false;
            add_process.Enabled = false;
            timer_tick.Interval = 1000;
            timer_tick.Tick += new EventHandler(timer_tick_Tick);
            timer_tick.Start();
            stopwatch.Start();
            sjf = new SJFScheduler(processes);
            if (processes.Count != 0)
            {
                foreach (var item in processes)
                {
                    processDataGridView.Rows.Add(item.ProcessName, item.ProcessID, item.ArrivalTime, item.CompletionTime, item.Burst_Time, item.Priority, item.State);
                }

                var runTasks = sjf.StartConvertToRunningOPeration();
                var resTask = sjf.Start();

                await Task.WhenAll(runTasks, resTask);

                if (resTask.IsCompleted)
                {
                    foreach (var res in resTask.Result)
                    {
                        processDataGridView.Rows.Add(res.ProcessName, res.ProcessID, res.ArrivalTime, res.CompletionTime, res.Burst_Time, res.Priority, res.State);
                    }
                    SetAllProcessToLaunch(processes);
                    begin_Init.Enabled = true;
                    add_process.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Inner process list doesn't have any process", "List Exception");
                begin_Init.Enabled = true;
                add_process.Enabled = true;
            }
            timer_tick.Stop();
            stopwatch.Stop();
            Timer_Label.Text = stopwatch.Elapsed.Seconds.ToString();
        }

        private async void begin_Init_Click(object sender, EventArgs e)
        {
            static_Init.Enabled = false;
            add_process.Enabled = false;
            timer_tick.Interval = 1000;
            timer_tick.Tick += new EventHandler(timer_tick_Tick);
            timer_tick.Start();
            stopwatch.Start();
            List<ProcessDomain> localStorage = new List<ProcessDomain>();
            localStorage = sjf.GetProcesses;
            timer_tick.Interval = 1000;

            if (localStorage.Count != 0)
            {
                foreach (var item in localStorage)
                {
                    processDataGridView.Rows.Add(item.ProcessName, item.ProcessID, item.ArrivalTime, item.CompletionTime, item.Burst_Time, item.Priority, item.State);
                }

                var runTasks = sjf.StartConvertToRunningOPeration();
                var resTask = sjf.Start();

                await Task.WhenAll(runTasks, resTask);

                if (resTask.IsCompleted)
                {
                    foreach (var res in resTask.Result)
                    {
                        processDataGridView.Rows.Add(res.ProcessName, res.ProcessID, res.ArrivalTime, res.CompletionTime, res.Burst_Time, res.Priority, res.State);
                    }
                    static_Init.Enabled = true;
                    add_process.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Inner process list doesn't have any process", "List Exception");
                static_Init.Enabled = true;
                add_process.Enabled = true;
            }
            timer_tick.Stop();
            stopwatch.Stop();
            Timer_Label.Text = stopwatch.Elapsed.Seconds.ToString();
        }

        private void add_process_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(processName_Text.Text) && !String.IsNullOrWhiteSpace(processID_Text.Text))
                {
                    sjf.AddProcess(new ProcessDomain
                    {
                        ProcessName = processName_Text.Text,
                        ProcessID = int.Parse(processID_Text.Text),
                        CompletionTime = SimpleRandomGenerator.GetRendomTime(),
                        Burst_Time = SimpleRandomGenerator.GetRendomTime(),
                        ArrivalTime = SimpleRandomGenerator.GetRendomTime(),
                        Priority = ProcessPriority.Normal,
                        State = ProcessState.New
                    });
                    processName_Text.Clear();
                    processID_Text.Clear();
                }
                else
                {
                    MessageBox.Show("Some input in textbox wrong");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer_tick_Tick(object sender, EventArgs e)
        {
            Timer_Label.Text = stopwatch.Elapsed.Seconds.ToString();
        }

        private List<ProcessDomain> SetAllProcessToLaunch(List<ProcessDomain> processes)
        {
            foreach (var item in processes)
            {
                if (processes.Exists(proc => proc.State != ProcessState.New))
                {
                    item.State = ProcessState.New;
                }
            }
            return processes;
        }


        private void interup_butt_Click(object sender, EventArgs e)
        {
            var cancelToken = new CancellationTokenSource();
            CancellationToken token = cancelToken.Token;

            cancelToken.Cancel();

            timer_tick.Stop();
            stopwatch.Stop();
            Timer_Label.Text = stopwatch.Elapsed.Seconds.ToString();
        }
    }
}