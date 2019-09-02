using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTest
{
    [Serializable]
    public class ExpectedResult
    {
        public string Category { get; set; }
        // public string Condition { get; set; } //TODO delete this field
        public string State { get; set; }
        public string Screen { get; set; }
        public string Text { get; set; }
        public string Journal { get; set; }
       // public string[] ConditionList { get; set; } //TODO delete this field

        public static void Main()
        {
            var a = new ExpectedResult
            {
            //    Condition = "mdt",
                State = "ddd",
                Text = "fdfdfdfasf"
            };
         //   Console.WriteLine(a.Condition);
        }
        //TODO delete this function
       /* public void CreateConditionList()
        {
            //throw new NotImplementedException();
            string str = Condition.TrimEnd(']').TrimStart('[');
            ConditionList = str.Split(',');
            //ConditionList.
        }*/
    }
}
