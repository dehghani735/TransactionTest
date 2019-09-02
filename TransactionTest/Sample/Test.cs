using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTest
{
    class Test
    {
        public static bool isCorrect_PIN = true;
        public static bool isAmount = true;
        public static bool isEnough_Cash = false;
        public static bool isOther = false;

//        public string isss { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        public override bool Equals(Object obj)
        {
            var other = obj as NDCTransactionReplyCommand;

            if (other == null)
                return false;

            if (Name != other.ReplyCommand)
                return false;

            return true;
        }

  /*      public static int counter = 0;
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
        }*/



        static void Main()
        {




          /*  Console.WriteLine(Test.isOther);

            Console.WriteLine(Test.isEnough_Cash);

            Console.WriteLine(Test.isAmount);
            */
            //var aa = new Test();
            // aa.isss = "mdt";

            //Console.WriteLine(aa.isss);

            //Console.WriteLine(aa.isss);

            /*string str = "";
            PrintTable(4, str);
            Console.WriteLine(counter + " " + flows.Count);
            
            NDCTransactionReplyCommand ndc = new NDCTransactionReplyCommand("ali");
            Test ts = new Test();
            ts.Name = "ali";
            ts.Age = 12;

            Console.WriteLine(ts.Equals(ndc));
            */
            

            //FROM HERE
           /* const string objectToInstantiate = "TransactionTest.Test";

            var objectType = Type.GetType(objectToInstantiate);
            //Console.WriteLine("==>: " + objectType.GetField("CardNumber"));
            var instantiatedObject = Activator.CreateInstance(objectType);

            TransactionConfig tf = new TransactionConfig(new Card());


            //tf.Amount = "555";

            //classType.InvokeMember("Sub", BindingFlags.InvokeMethod, null, instance, new object[] { 23, 42 });
           /* Console.WriteLine(objectType.InvokeMember("fff", BindingFlags.InvokeMethod, null, instantiatedObject,
                new object[] { tf }));
                */
                /*
            Console.WriteLine("mdt: " + objectType.InvokeMember("isEnough_Cash", BindingFlags.GetField, null, instantiatedObject, null));
            //Console.WriteLine(objectType.InvokeMember());

            Console.WriteLine(instantiatedObject.ToString());
            */
            // TO HERE


            var ali = true;
            Console.WriteLine(nameof(ali));
        }
    }
}
