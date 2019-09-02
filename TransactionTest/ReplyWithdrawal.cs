using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTest
{
    class ReplyWithdrawal : NDCTransactionReplyCommand
    {
        public ReplyWithdrawal(string replyCommand) : base(replyCommand)
        {
        }

        public override bool Equals(Object obj)
        {
            // Specifically Equal method for Withdrawal transaction
            Console.WriteLine("ReplyWithdrawal started");
            return false;
        }
    }
}
