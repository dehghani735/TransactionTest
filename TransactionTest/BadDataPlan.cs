using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTest
{
    public class BadDataPlan : Plan
    {
        public BadDataPlan(string description, Network network, TransactionConfig transactionConfig) : base(description, network, transactionConfig)
        {
        }

        public override void CreateTransactions()
        {
            // Console.WriteLine("===Start Plan.BadDataPlan()===");
            Transactions.Add(new Balance(TransactionConfig));
            Transactions.Add(new Withdrawal(TransactionConfig));
            Transactions.Add(new Balance(TransactionConfig));
        }


    }
}
