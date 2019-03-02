using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTest
{
    public abstract class Plan // TODO: as Command
    {
        private TransactionConfig _transactionConfig;
        private string _description; // each plan has a description describing the purpose or condition of the plan
        private List<Transaction> _transactions; // list of transactions
        protected readonly Network _network;

        public Plan(string description, Network network, TransactionConfig transactionConfig)
        {
            _transactionConfig = transactionConfig;
            _description = description;
            _transactions = new List<Transaction>();
            _network = network;
            // TODO: call CreateTransactions()
            this.CreateTransactions();
            this.ShowTransactions();
        }

        public string Description
        {
            get { return _description; }
        }

        public List<Transaction> Transactions
        {
            get { return _transactions; }
        }

        public TransactionConfig TransactionConfig
        {
            get { return _transactionConfig; }
        }
    
        // process before;
        // iterate in
        // process after; 

        public abstract void CreateTransactions(); // factory method

        public void ShowTransactions()
        {
            Console.Write(this.GetType().Name + " [" + Description + "] : ");

            foreach (var transaction in Transactions)
            {
                Console.Write(transaction.GetType().Name + " | ");
            }
            Console.WriteLine("");
        }

        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        // to process the transactions of the plan
        public string Process()
        {
            var report = new StringBuilder();

            report.Append(this.GetType().Name.PadRight(20) + " [" + Description.PadRight(40) + "] : \t\t");

            foreach (var transaction in _transactions)
            {
                report.Append(transaction.Process(_network) + " | ");
            }
            return report.ToString();
        }
    }
}
