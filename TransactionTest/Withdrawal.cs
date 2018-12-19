using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTest
{
    class Withdrawal : NDCTransactionRequestMessage
    {
        public Withdrawal(Config config) : base()
        {
            AmountEntryField = config.Amount;
            OperationCodeData = "ADFI   A";
        }

        /*public override void ali()
        {
            throw new NotImplementedException();
        }*/

//        "11&#28;000&#28;&#28;&#28;1?&#28;;5894631511409724=99105061710399300020?&#28;&#28;ADFI   A&#28;000000500000&#28;&gt;106&lt;?1&gt;82&lt;7&gt;9=2&#28;&#28;&#28;&#28;20000100000000000000000000";
    }
}