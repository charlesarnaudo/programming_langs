using System;
using System.Diagnostics;

namespace comp3350_lab8
{
    public class Part2
    {
        Stopwatch timer;

        public Part2() {

        }

        /* Write your code in this method */
        public void Run()
        {
            timer = Stopwatch.StartNew();
            int count = 0;
            LargeObject[] objs = new LargeObject[10000];

            for (int i = 0; i < 10000; i ++) {
                objs[i] = new LargeObject();
                GC.PrintTime(i, timer);
                count++;
                if (count == 1000) {
                    System.GC.Collect(0);
                    count = 0;
                }
            }
            System.GC.Collect();
        }
    }
}

