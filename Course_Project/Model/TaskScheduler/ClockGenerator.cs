using System;
using System.Threading;

namespace Model.TaskScheduler
{
    public class ClockGenerator
    {
        static int count = 0;
        public ClockGenerator(TimerCallback callback, Timer timer)
        {
            // устанавливаем метод обратного вызова
            callback = new TimerCallback(Count);
            // создаем таймер
            timer = new Timer(callback, count, 0, 1000);
        }

        private void Count(object obj)
        {
            count++;
            Console.WriteLine($"{count} seconds have passed");
        }

        public void Stop()
        {
            try
            {
                Environment.Exit(0);
            }
            catch (ThreadAbortException threadEx)
            {
                Console.WriteLine("All processes done! {0}", threadEx.Message);
            }
        }
    }
}
