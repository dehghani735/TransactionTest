using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTest
{
    public class Transfer : NdcTransactionRequestMessage
    {
        public Transfer(TransactionConfig transactionConfig) : base(transactionConfig)
        {
            //TODO: is not correct
            AmountEntryField = "000000000000";
            OperationCodeData = "AAAC   A";
        }

        public override void Ali()
        {
            Console.WriteLine("ali transfer");
        }

    }
}
