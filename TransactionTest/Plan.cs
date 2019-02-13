using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTest
{
    public class Plan
    {
        //field: list of transactions
        private List<Transaction> _transactions;

        public Plan()
        {
            _transactions = new List<Transaction>();
        }
        
        public List<Transaction> Transactions
        {
            get { return _transactions; }
        }

        // process before; //TODO
        // iterate in
        // process after; //TODO

        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        // to process the transactions of the plan
        public void Process(Config config)
        {
            foreach (var transaction in _transactions)
            {
                transaction.Process(config);
            }
        }
    }
}
