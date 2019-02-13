using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTest
{
    public abstract class Transaction
    {
        public abstract void Ali();
        
        public abstract void Process(Config config);
    }
}
