using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TransactionTest
{
    public class EventParameter
    {
        public static void Main()
        {
            Adder1 a = new Adder1();
            a.OnMultipleOfFiveReached += a_MultipleOfFiveReached;
            int iAnswer = a.Add(3, 4);
            Console.WriteLine(iAnswer);

            int iAnswer2 = a.Add(4, 6);
            Console.WriteLine(iAnswer2);
        }

        static void a_MultipleOfFiveReached(object sender, MultipleOfFiveEventArgs e)
        {
            Console.WriteLine("Multiple of Five Reached!: " + e.Total);
        }
    }

    class Adder1
    {
        public event EventHandler<MultipleOfFiveEventArgs> OnMultipleOfFiveReached;

        public int Add(int x, int y)
        {
            int iSum = x + y;
            if ((iSum % 5 == 0) && (OnMultipleOfFiveReached != null))
            {
                OnMultipleOfFiveReached(this, new MultipleOfFiveEventArgs(iSum));
            }
            return iSum;
        }
    }

    public class MultipleOfFiveEventArgs : EventArgs
    {
        public MultipleOfFiveEventArgs(int a)
        {
            Total = a;
        }

        public int Total { get; set; }
    }
}