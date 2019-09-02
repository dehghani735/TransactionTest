using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTest
{
    public class Balance : NdcTransactionRequestMessage
    {
        public static bool isCorrect_PIN = true;
        public static bool isAmount = true;
        public static bool isEnough_Cash = false;
        public static bool isOther = false;


        public Balance(TransactionConfig transactionConfig) : base(transactionConfig)
        {
            AmountEntryField = "000000000000";
            OperationCodeData = "AAAC   A";
        }

        public Balance()
        {
            
        }

        public void fff(TransactionConfig tf)
        {
            Console.WriteLine(tf.Card.CardNumber);
        }

        public override void Ali()
        {
            Console.WriteLine("ali balance");
        }

        public override string Process(Network network)
        {
            //TODO: a list of Msgs that form a Plan to send
            var msg = this.GetNdcTransactionRequestMessage();

            var received = ""; //network.SendAndReceive(msg); //TODO
            Console.WriteLine("Received: " + received);

            var replyCommand = new ReplyBalance(received);

            if (replyCommand.parseReplyCommand())
            {
                //TODO
                if (replyCommand.Equals(this.TransactionConfig.ExpectedResult))
                {
                    return this.GetType().Name + " (Passed)";
                }
                return this.GetType().Name + " (Failed)";
            }
            else
            {
                return this.GetType().Name + "Exception Occurred in Parsing NDCTransactionReplyCommand(Failed)";
            }
        }

        //        "11&#28;000&#28;&#28;&#28;18&#28;;5894631511409724=99105061710399300020?&#28;&#28;AAAC   A&#28;000000000000&#28;&gt;106&lt;?1&gt;82&lt;7&gt;9=2&#28;&#28;&#28;&#28;20000100000000000000000000";
        //        "11&#28;000&#28;&#28;&#28;1?&#28;;5894631511409724=99105061710399300020?&#28;&#28;ADFI   A&#28;000000500000&#28;&gt;106&lt;?1&gt;82&lt;7&gt;9=2&#28;&#28;&#28;&#28;20000100000000000000000000";    }
    }
}