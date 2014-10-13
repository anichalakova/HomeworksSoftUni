using System;

namespace Problem2_AsynchronousTimer
{    
    public class AsyncTimer
    {

        private int ticks = 0;
        private int interval = 0;
        public Action<int> action;

        public AsyncTimer(int ticks, int interval, Action<int> action)
        {
            this.ticks = ticks;
            this.interval = interval;
            this.action = action;
        }

        
        public void PrintTicks(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("tick!");
            }            
        }
    }
}
