using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TransactionTest
{
    public class PlanFactory  // TODO: as invoker
    {
        private readonly Config _config;

        private List<string> _flows = new List<string>();

        private BlockingCollection<Plan> _plans = new BlockingCollection<Plan>();
        //private List<Plan> _plans;

        public PlanFactory(Config config)
        {
            _config = config;
        }

        public void PrintTable(int n, string s)
        {
            if (n == 0)
            {
                Console.WriteLine(s);
                _flows.Add(s);
                //counter++;
                return;
            }
            PrintTable(n - 1, s + "T");
            PrintTable(n - 1, s + "F");
        }

        public void GeneratePlans()
        {
            Console.WriteLine("===Start PlanFactory.GeneratePlans()===");
            string s = "";
            PrintTable(_config.Condition.Count, s);
            Console.WriteLine(_flows.Count);

            var result = new List<string>();

            foreach (var flow in _flows)
            {
                var newFlow = new StringBuilder();

                for (int i = 0; i < flow.Length; i++)
                {
                    if (flow[i] == 'T')
                    {
                        newFlow.Append(_config.Condition[i] + " ");

                        Console.WriteLine(_config.Condition[i]);
                    }
                    else
                    {
                        newFlow.Append("!" + _config.Condition[i] + " ");
                        Console.WriteLine("!" + _config.Condition[i]);
                    }
                }
                result.Add(newFlow.ToString());
                Console.WriteLine("+++++++++++++++++++++");
            }

            foreach (var str in result)
            {
                Console.WriteLine(str);
            }

            //_plans = new List<Plan>();

            //TODO: generate the list of plans base on the config file
            
            // Condition-based plans
            foreach (var financial in _config.Financial)
            {
                if (financial.Equals("Withdrawal", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (_config.Condition.Contains("Incorrect_PIN", StringComparer.InvariantCultureIgnoreCase))
                        _plans.Add(new ConditionBasedPlan("Incorrect Pin", _config.GetNetwork("ATM"), new TransactionConfig(_config.Card[0], "1111")));

                    if (_config.Condition.Contains("Not_Enough_Cash", StringComparer.InvariantCultureIgnoreCase))
                        _plans.Add(new ConditionBasedPlan("Not Enough Cash", _config.GetNetwork("ATM"), new TransactionConfig(_config.Card[0])));

                    if (_config.Condition.Contains("Incorrect_PIN", StringComparer.InvariantCultureIgnoreCase) && _config.Condition.Contains("Not_Enough_Cash", StringComparer.InvariantCultureIgnoreCase))
                        _plans.Add(new ConditionBasedPlan("Incorrect PIN and Not Enough Cash", _config.GetNetwork("ATM"), new TransactionConfig(_config.Card[0], "1111")));

                    _plans.Add(new ConditionBasedPlan("All inputs are Correct", _config.GetNetwork("ATM"), new TransactionConfig(_config.Card[0])));
                }
            }
            /*
            // Reverse plans
            
            foreach (var financial in _config.Financial)
            {
                if (financial.Equals("Withdrawal", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (_config.Reverse.Contains("Not_Withdrawal", StringComparer.InvariantCultureIgnoreCase))
                        _plans.Add(new ReversePlan("Not_Withdrawal; don't take card", _config.GetNetwork("ATM"), new TransactionConfig(_config.Card[0])));
                }
            }
            
            // BadData plans
            
            foreach (var financial in _config.Financial)
            {
                if (financial.Equals("Withdrawal", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (_config.BadData.Contains("Amount", StringComparer.InvariantCultureIgnoreCase))
                        _plans.Add(new BadDataPlan("Bad Amount Data", _config.GetNetwork("ATM"), new TransactionConfig(_config.Card[0])));  // TODO: transaction config should be corrected

                    if (_config.BadData.Contains("PIN", StringComparer.InvariantCultureIgnoreCase))
                        _plans.Add(new BadDataPlan("Bad PIN Data", _config.GetNetwork("ATM"), new TransactionConfig(_config.Card[0])));     // TODO: transaction config should be corrected

                    if (_config.BadData.Contains("Track", StringComparer.InvariantCultureIgnoreCase))
                        _plans.Add(new BadDataPlan("Bad Track Data", _config.GetNetwork("ATM"), new TransactionConfig(_config.Card[0])));   // TODO: transaction config should be corrected
                }
            }
            
            // Complete plans
            
            foreach (var complete in _config.Complete)
            {
                if (complete.Equals("Balance", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (_config.Condition.Contains("Incorrect_PIN", StringComparer.InvariantCultureIgnoreCase))
                        _plans.Add(new CompletePlan("Incorrect Pin", _config.GetNetwork("ATM"), new TransactionConfig(_config.Card[0])));  // TODO: transaction config should be corrected

                    _plans.Add(new CompletePlan("All inputs are Correct", _config.GetNetwork("ATM"), new TransactionConfig(_config.Card[0])));
                }
            }
            */
        }

        static void Main()
        {

        }

        public void ProcessPendingPlans()
        {
            Console.WriteLine("start pending!");

            Parallel.ForEach(_plans, plan =>
                {
                    Reporter.Log(plan.Process());

                }
            );

            // Thread th = new Thread(new ThreadStart());
            // th.Start();

            /*foreach (var plan in _plans)
            {
                // ThreadStart childref = new ThreadStart();
                Reporter.Log(plan.Process());

                //Thread.Sleep(5000);
                //System.Threading.Thread.Sleep(4000);
            }*/
        }
    }
}