using Model.Process;
using Model.TaskScheduler;
using Model.TaskScheduler.Scheduler;
using Model.Utility.Priority;
using System;
using System.Collections.Generic;
using System.Threading;

namespace TestSJFAlgorithm.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TimerCallback callback = null;
            Timer timer = null;
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            List<ProcessDomain> processes = new List<ProcessDomain>
            {
                new ProcessDomain { ProcessName = "p0", ProcessID = 4, State = ProcessState.Running, Priority = ProcessPriority.Normal },
                new ProcessDomain { ProcessName = "p1", ProcessID = 5, State = ProcessState.Completed, Priority = ProcessPriority.Normal },
                new ProcessDomain { ProcessName = "p2", ProcessID = 6, State = ProcessState.Completed, Priority = ProcessPriority.Normal },
                new ProcessDomain { ProcessName = "p3", ProcessID = 7, State = ProcessState.Completed, Priority = ProcessPriority.Normal }
            };

            foreach (var item in GetAllProcess(processes))
            {
                Console.WriteLine(item);
            }

            ClockGenerator clock = new ClockGenerator(callback, timer);
            SJFScheduler sjf = new SJFScheduler(processes);
            var runTasks = sjf.StartConvertToRunningOPeration();
            var resTask = sjf.Start();


            //nonpreemptive imitation
            Thread.Sleep(500);
            sjf.AddProcess(new ProcessDomain { ProcessName = "p3", ProcessID = 8, State = ProcessState.New, Priority = ProcessPriority.Normal });

            resTask.Wait();

            if (resTask.IsCompleted)
            {
                foreach (var res in resTask.Result)
                {
                    Console.WriteLine(res);
                }
            }
            clock.Stop();
            Console.Read();
        }

        public static IEnumerable<String> GetAllProcess(List<ProcessDomain> processes)
        {
            foreach (var item in processes)
            {
                if (processes.Exists(proc => proc.State != ProcessState.New))
                {
                    item.State = ProcessState.New;
                }
                yield return item.ToString();
            }
        }

    }
}
