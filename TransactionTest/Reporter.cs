using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TransactionTest
{
    public static class Reporter
    {
        private static ReportBase reporter = new FileReporter();

        public static void Log(string log)
        {
            reporter.Log(log);
        }
    }
}
