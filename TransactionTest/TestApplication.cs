using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
//using NUnit.Framework.Internal;

namespace TransactionTest
{
    class TestApplication
    {
        static void Main()
        {
            var config = new Config();
            config.ReadFile();
            config.Parse();

            var planFactory = new PlanFactory(config);
            
            // TODO: generate plans is incomplete
            planFactory.GeneratePlans();

            Reporter.Log(System.DateTime.Now.ToString());

            planFactory.ProcessPendingPlans();
        }
    }
}