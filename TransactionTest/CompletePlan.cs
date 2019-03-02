using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTest
{
    public class CompletePlan : Plan
    {
        public CompletePlan(string description, Network network, TransactionConfig transactionConfig) : base(description, network, transactionConfig)
        {
        }

        public override void CreateTransactions()
        {
            //Console.WriteLine("===Start Plan.CompletePlan()===");
            Transactions.Add(new Balance(TransactionConfig));
        }

    }
}
