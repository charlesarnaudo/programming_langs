using System;
using System.Diagnostics;

namespace comp3350_lab8
{
    public class Part1
    {
        Stopwatch timer;

        public Part1() {

        }

        /* Write your code in this method */
        public void Run()
        {
            timer = Stopwatch.StartNew();
            int count = 0;
            for (int i = 0; i < 10000; i ++) {
                new LargeObject();
                GC.PrintTime(i, timer);
                count++;
                if (count == 1000) {
                    System.GC.Collect();
                    count = 0;
                }
            }
            System.GC.Collect();
        }
    }
}
