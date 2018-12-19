using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTest
{
    public class PlanFactory
    {
        private readonly Config _config;
        private List<String> _flows;

        public PlanFactory(Config config)
        {
            _config = config;
        }

        public List<NDCTransactionRequestMessage> GenerateFlows()
        {
            var list = new List<NDCTransactionRequestMessage>();
            /*
            private List<string> _financial;
            private List<string> _nonFinancial;
            private List<string> _complete;
            private List<string> _condition;
            private List<string> _beforeChecking;
            private List<string> _afterChecking;
            private List<string> _reverse;
            private List<string> _badData;
            private List<Card> _card;
            private string _amount;

            Console.WriteLine("Cards count: " + _config.Card[0].Track);
            Console.WriteLine("**************************************************");

            foreach (var financial in _config.Financial)
            {
                Console.WriteLine(financial);

                String a = "a";
                String b = "b";
                String c = "c";


                for (int i = 0; i < 3; i++)
                {
                }
            }
            */


            list.Add(new Balance());

            list.Add(new Withdrawal(_config));

            list.Add(new Balance());
            return list;
        }

        static void Main()
        {
            var config = new Config();
            config.ReadFile();
            config.Parse();
            Network nt = new Network(config.GetNetworkConfig());
            var pf = new PlanFactory(config);
            var list = pf.GenerateFlows();
            foreach (var flow in list)
            {
                var msg = flow.getNDCTransactionRequestMessage();
                Console.WriteLine(msg);
            }
            //pf.GenerateFlows();
        }
    }
}