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
        CancellationTokenSource Source;

        public Form1()
        {
            InitializeComponent();
            SetAllProcessToLaunch(processes);
            sjf = new SJFScheduler();
        }

        private async void static_Init_Click(object sender, EventArgs e)
        {
            Source = new CancellationTokenSource();
            begin_Init.Enabled = false;
            add_process.Enabled = false;
            timer_tick.Interval = 1000;
            timer_tick.Tick += new EventHandler(timer_tick_Tick);
            timer_tick.Start();
            stopwatch.Start();
            sjf = new SJFScheduler(processes);
            List<ProcessDomain> local = new List<ProcessDomain>();
            try
            {
                if (processes.Count != 0)
                {
                    foreach (var item in processes)
                    {
                        processDataGridView.Rows.Add(item.ProcessName, item.ProcessID, item.ArrivalTime, item.CompletionTime, item.Burst_Time, item.Priority, item.State);
                    }

                    var runTasks = await Task.Run(() => sjf.StartConvertToRunningOperation(Source.Token));
                    var resTask = await Task.Run(() => sjf.Start(Source.Token));


                    local = resTask;
                    if (local.Count != 0 && !Source.IsCancellationRequested)
                    {
                        foreach (var res in local)
                        {
                            processDataGridView.Rows.Add(res.ProcessName, res.ProcessID, res.ArrivalTime, res.CompletionTime, res.Burst_Time, res.Priority, res.State);
                        }
                        SetAllProcessToLaunch(processes);
                        begin_Init.Enabled = true;
                        add_process.Enabled = true;
                    }
                    else
                    {
                        foreach (var res in local)
                        {
                            if (res.State == ProcessState.Completed)
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
            }
            catch (OperationCanceledException ex)
            {
                MessageBox.Show(ex.Message, "Operation Canceled Exception");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Source.Dispose();
                timer_tick.Stop();
                stopwatch.Stop();
                Timer_Label.Text = stopwatch.Elapsed.Seconds.ToString();
            }
        }

        private async void begin_Init_Click(object sender, EventArgs e)
        {
            static_Init.Enabled = false;
            add_process.Enabled = false;
            Source = new CancellationTokenSource();
            timer_tick.Interval = 1000;
            timer_tick.Tick += new EventHandler(timer_tick_Tick);
            timer_tick.Start();
            stopwatch.Start();
            List<ProcessDomain> localStorage = new List<ProcessDomain>();
            localStorage = sjf.GetProcesses;
            try
            {
                if (localStorage.Count >= 1)
                {
                    foreach (var item in localStorage)
                    {
                        processDataGridView.Rows.Add(item.ProcessName, item.ProcessID, item.ArrivalTime, item.CompletionTime, item.Burst_Time, item.Priority, item.State);
                    }
                    var runTasks = await Task.Run(() => sjf.StartConvertToRunningOperation(Source.Token));
                    var resTask = await Task.Run(() => sjf.Start(Source.Token));

                    localStorage = resTask;
                    if (localStorage.Count != 0 && !Source.IsCancellationRequested)
                    {
                        foreach (var res in localStorage)
                        {
                            processDataGridView.Rows.Add(res.ProcessName, res.ProcessID, res.ArrivalTime, res.CompletionTime, res.Burst_Time, res.Priority, res.State);
                        }
                        SetAllProcessToLaunch(processes);
                        static_Init.Enabled = true;
                        add_process.Enabled = true;
                    }
                    else
                    {
                        foreach (var res in localStorage)
                        {
                            if (res.State == ProcessState.Completed)
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
                    static_Init.Enabled = true;
                    add_process.Enabled = true;
                }
            }
            catch (OperationCanceledException ex)
            {
                MessageBox.Show(ex.Message, "Operation Canceled Exception");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                static_Init.Enabled = true;
                add_process.Enabled = true;
                sjf.GetProcesses.Clear();
                Source.Dispose();
                timer_tick.Stop();
                stopwatch.Stop();
                Timer_Label.Text = stopwatch.Elapsed.Seconds.ToString();
            }
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
            try
            {
                if (Source != null)
                {
                    Source.Cancel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Interrupted Exception");
            }
            finally
            {
                Source.Dispose();
                timer_tick.Stop();
                stopwatch.Stop();
                Timer_Label.Text = stopwatch.Elapsed.Seconds.ToString();
            }
        }
    }
}