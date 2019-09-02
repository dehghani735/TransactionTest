using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TransactionTest
{
    public class EventNotification
    {
        public static void Main()
        {
            Adder a = new Adder();
            a.OnMultipleOfFiveReached += a_MultipleOfFiveReached;
            int iAnswer = a.Add(3, 4);
            Console.WriteLine(iAnswer);

            int iAnswer2 = a.Add(4, 6);
            Console.WriteLine(iAnswer2);

            /*
            // Queue the task.
            ThreadPool.QueueUserWorkItem(ThreadProc);
            Console.WriteLine("Main thread does some work, then sleeps.");
            Thread.Sleep(1000);

            Console.WriteLine("Main thread exits.");
            */

            /* Thread th = Thread.CurrentThread;
             th.Name = "MainThread";

             Console.WriteLine("This is {0}", th.ThreadState);

             Console.WriteLine("This is {0}", th.Name);
             //Console.ReadKey();
             */
        }

        static void a_MultipleOfFiveReached(object sender, EventArgs e)
        {
            Console.WriteLine("Multiple of Five Reached!");
        }

        // This thread procedure performs the task.
 /*       static void ThreadProc(Object stateInfo)
        {
            // No state object was passed to QueueUserWorkItem, so stateInfo is null.
            Console.WriteLine("Hello from the thread pool.");
        }
        */
    }

     class Adder
     {
        public event EventHandler OnMultipleOfFiveReached;

        public int Add(int x, int y)
        {
            int iSum = x + y;
            if ((iSum%5 == 0) && (OnMultipleOfFiveReached != null))
            {
                OnMultipleOfFiveReached(this, EventArgs.Empty);
            }
            return iSum;
        }
    }
}