using System;
using System.Diagnostics;

namespace comp3350_lab8
{
    public class Part3
    {
        Stopwatch timer;

        public Part3() {

        }

        /* Write your code in this method */
        public void Run()
        {
            timer = Stopwatch.StartNew();
            long oldtime = 0;

            for (int i = 0; i < 10000; i ++) {
                new LargeObject(10000);
                long difftime = timer.ElapsedTicks - oldtime;
                oldtime = timer.ElapsedTicks;
                Console.Out.WriteLine(i + "\t" + difftime);
            }
            System.GC.Collect();
        }
    }
}
