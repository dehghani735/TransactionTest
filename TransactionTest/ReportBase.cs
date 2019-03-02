using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTest
{
    public abstract class ReportBase
    {
        public abstract void Log(string log);
    }

    public class FileReporter : ReportBase
    {
        public string filePath = @"C:\Users\m.dehghani\source\repos\TransactionTest\TransactionTest\Report.txt";

        public override void Log(string log)
        {
            using (StreamWriter streamWriter = File.AppendText(filePath)) // File(filePath))
            {
                streamWriter.WriteLine(log);
                streamWriter.Close(); // TODO: to the end of logging
            }
        }
    }
}
