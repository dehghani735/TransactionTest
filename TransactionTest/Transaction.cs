using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTest
{
    public abstract class Transaction //: IStatus // TODO: as Receiver i think
    {
        private TransactionConfig _transactionConfig;

        public Transaction(TransactionConfig transactionConfig)
        {
            TransactionConfig = transactionConfig;
        }

        public Transaction() { }

        public TransactionConfig TransactionConfig
        {
            get { return _transactionConfig; }
            set { _transactionConfig = value; }
        }

        public abstract void Ali();
        
        public abstract string Process(Network network);

    }
}
