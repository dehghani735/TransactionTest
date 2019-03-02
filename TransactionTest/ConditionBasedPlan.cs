using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTest
{
    public class ConditionBasedPlan : Plan // TODO: as ConcreteCommand
    {
        public ConditionBasedPlan(string description, Network network, TransactionConfig transactionConfig) : base(description, network, transactionConfig)
        {
        }

        public override void CreateTransactions()
        {
            // Console.WriteLine("===Start Plan.ConditionBasedPlan()===");
            Transactions.Add(new Balance(TransactionConfig));
            Transactions.Add(new Withdrawal(TransactionConfig));
            Transactions.Add(new Balance(TransactionConfig));


        }
    }
}
