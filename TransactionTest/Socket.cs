using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTest
{
    public abstract class Socket : Transaction
    {
        public abstract string GetNdcTransactionRequestMessage();
    }
}