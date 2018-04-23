using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;

namespace My_Generic
{
  
    class Program
    {
        static void Main(string[] args)
        {
            var alInt = new ArrayList();
            var alString = new ArrayList();
            var lInt = new List<int>();
            var lString = new List<string>();
            //////////////////////////////////////////////////////
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            

            Console.WriteLine("ArrayList int");
            long t1 = Stopwatch.GetTimestamp();
            int count = GC.CollectionCount(0);
            for (int i = 0; i < 1000000; ++i)
            {
                alInt.Add(i);
                int a = (int)alInt[i];
            }
            Console.WriteLine((Stopwatch.GetTimestamp()-t1)/(double)Stopwatch.Frequency);
            Console.WriteLine(GC.CollectionCount(0)-count);
            /////////////////////////
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Console.WriteLine("ArrayList string");
            long t2 = Stopwatch.GetTimestamp();
            int count2 = GC.CollectionCount(0);
            for (int i = 0; i < 1000000; ++i)
            {
                alString.Add(i.ToString());
                string a = (string)alString[i];
            }
            Console.WriteLine((Stopwatch.GetTimestamp() - t2) / (double)Stopwatch.Frequency);
            Console.WriteLine(GC.CollectionCount(0) - count2);

            /////////////////////////////////////////////////////
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Console.WriteLine("List int");
            long tL1 = Stopwatch.GetTimestamp();
            int countL = GC.CollectionCount(0);
            for (int i = 0; i < 1000000; ++i)
            {
                lInt.Add(i);
                int a = lInt[i];
            }
            Console.WriteLine((Stopwatch.GetTimestamp() - tL1) / (double)Stopwatch.Frequency);
            Console.WriteLine(GC.CollectionCount(0) - countL);
            /////////////////
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Console.WriteLine("List string");
            long tL2 = Stopwatch.GetTimestamp();
            int countL2 = GC.CollectionCount(0);
            for (int i = 0; i < 1000000; ++i)
            {
                lString.Add(i.ToString());
                string a = lString[i];
            }
            Console.WriteLine((Stopwatch.GetTimestamp() - tL2) / (double)Stopwatch.Frequency);
            Console.WriteLine(GC.CollectionCount(0) - countL2);

            Console.ReadKey();
        }
    }

}
