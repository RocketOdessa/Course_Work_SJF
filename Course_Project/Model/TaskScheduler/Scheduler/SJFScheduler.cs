using Model.Process;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Model.TaskScheduler.Scheduler
{

    public class SJFScheduler
    {
        List<ProcessDomain> processes;
        List<ProcessDomain> runningProcess;
        readonly object SJFLock = new object();
        bool workDone = false;

        public SJFScheduler()
        {
            processes = new List<ProcessDomain>();
            runningProcess = new List<ProcessDomain>();
        }

        public SJFScheduler(IEnumerable<ProcessDomain> Processes)
        {
            processes = new List<ProcessDomain>();
            runningProcess = new List<ProcessDomain>();
            processes.AddRange(Processes);
        }

        public void AddProcess(ProcessDomain process)
        {
            workDone = false;
            if (workDone == false)
            {
                lock (SJFLock)
                {
                    processes.Add(process);
                }
            }
        }

        public List<ProcessDomain> GetProcesses
        {
            get => processes;
        }

        public async Task<List<ProcessDomain>> StartConvertToRunningOperation(CancellationToken Token)
        {
            return await WorkWithRunningList(Token);
        }

        public async Task<List<ProcessDomain>> Start(CancellationToken Token)
        {
            return await Work(Token);
        }

        private async Task<List<ProcessDomain>> Work(CancellationToken ct)
        {
            List<ProcessDomain> workResult = new List<ProcessDomain>();

            while (runningProcess.Exists(p => p.State == ProcessState.Running) && !ct.IsCancellationRequested)
            {
                ProcessDomain execProc = null;
                lock (SJFLock)
                {

                    int minDuration = runningProcess.Where(proc => proc.State == ProcessState.Running).Min(p => p.Burst_Time);
                    execProc = runningProcess.First(p => p.Burst_Time == minDuration && p.State == ProcessState.Running);
                    execProc.State = ProcessState.Completed;
                    workResult.Add(execProc);

                }

                //for work imitation
                Thread.Sleep(execProc.Burst_Time * 1000);
            }

            workDone = true;
            return workResult;
        }

        private async Task<List<ProcessDomain>> WorkWithRunningList(CancellationToken ct)
        {
            foreach (var item in processes)
            {
                if (processes.Exists(proc => proc.State == ProcessState.Running))
                    item.State = ProcessState.New;
                else if (processes.Exists(proc => proc.State == ProcessState.Interrupted))
                    item.State = ProcessState.New;
                else if (processes.Exists(proc => proc.State == ProcessState.Completed))
                    item.State = ProcessState.New;
            }


            while (processes.Exists(procRun => procRun.State == ProcessState.New))
            {
                ProcessDomain tempDomainObject = null;
                lock (SJFLock)
                {
                    if (ct.IsCancellationRequested)
                    {
                        ct.ThrowIfCancellationRequested();
                        tempDomainObject = processes.Find(p => p.State == ProcessState.New);
                        tempDomainObject.State = ProcessState.Interrupted;
                        runningProcess.Add(tempDomainObject);
                    }
                    else
                    {
                        tempDomainObject = processes.Find(p => p.State == ProcessState.New);
                        tempDomainObject.State = ProcessState.Running;
                        runningProcess.Add(tempDomainObject);
                    }
                }
            }
            return runningProcess;
        }
    }
}