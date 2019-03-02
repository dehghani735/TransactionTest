using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTest
{
    class Test
    {
        public static int counter = 0;
        public static List<string> flows = new List<string>();

        public static void PrintTable(int n, string s)
        {
            if (n == 0)
            {
                Console.WriteLine(s);
                flows.Add(s);
                counter++;
                return;
            }
            PrintTable(n - 1, s + " T");
            PrintTable(n - 1, s + " F");
        }

        static void Main()
        {
            string str = "";
            PrintTable(4, str);
            Console.WriteLine(counter + " " + flows.Count);

        }
    }
}
