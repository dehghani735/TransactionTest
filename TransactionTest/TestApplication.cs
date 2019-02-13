using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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
            var plans = planFactory.GeneratePlans();

            foreach (var plan in plans)
            {
                plan.Process(config);

                /*
                foreach (var transaction in plan.Transactions)
                {
                    //TODO: a list of Msgs that form a flow to send
                    var msg = transaction.GetNdcTransactionRequestMessage();
                    transaction.Ali();
                    Console.WriteLine(config.GetNetwork("ATM").SendAndReceive(msg));
                }
                */
            }
        }
    }
}