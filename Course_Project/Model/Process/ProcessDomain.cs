using Model.Utility;
using Model.Utility.Priority;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Process
{
    public sealed partial class ProcessDomain
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Need Process Name"), MinLength(20, ErrorMessage = "Invalid Name")]
        public string ProcessName { get; set; }

        [Required(ErrorMessage = "Need Process ID")]
        public int ProcessID { get; set; }

        [Required(ErrorMessage = "Need Process Completion Time")]
        public int CompletionTime { get; set; }

        [Required(ErrorMessage = "Need Arrival Time")]
        public int ArrivalTime { get; set; }

        [Required(ErrorMessage = "Need Burst Time")]
        public int Burst_Time { get; set; }

        public ProcessPriority Priority { get; set; }

        public ProcessState State { get; set; }

    }

    public sealed partial class ProcessDomain
    {
        static int count = 0;
        public ProcessDomain()
        {
            ProcessName = $"P{count++}";
            ProcessID = count;
            CompletionTime = SimpleRandomGenerator.GetRendomTime();
            ArrivalTime = SimpleRandomGenerator.GetRendomTime();
            Burst_Time = SimpleRandomGenerator.GetRendomTime();
            State = ProcessState.New;
            Priority = ProcessPriority.Normal;

        }

        public ProcessDomain(string Name, int processID, ProcessState state, ProcessPriority priority)
            : this(Name, processID, 0, 0, 0, state, priority)
        {
            CompletionTime = SimpleRandomGenerator.GetRendomTime();
            ArrivalTime = SimpleRandomGenerator.GetRendomTime();
            Burst_Time = SimpleRandomGenerator.GetRendomTime();
        }

        public ProcessDomain(string Name, int processID, int coTime, int arTime, int brTime, ProcessState state, ProcessPriority priority)
        {
            ProcessName = Name;
            ProcessID = processID;
            CompletionTime = coTime;
            ArrivalTime = arTime;
            Burst_Time = brTime;
            State = state;
            Priority = priority;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            return builder.Append($"Process Name: {ProcessName}\n Process ID: {ProcessID}\n Completion Time: {CompletionTime}\n Arrival Time:{ArrivalTime}\n " +
                $"Burst Time:{Burst_Time}\n Process State:{State}\n Priority:{Priority}").ToString();
        }
    }
}
