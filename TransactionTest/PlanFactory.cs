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
        private List<Plan> _plans; //TODO: I'm not sure if it should be here or not
        
        public PlanFactory(Config config)
        {
            _config = config;
        }

        public List<Plan> GeneratePlans()
        {
            Console.WriteLine("===Start PlanFactory.GeneratePlans()===");

            var plans = new List<Plan>();

            //TODO: generate the list of plans base on the config file

            var plan = new Plan();

            foreach (string i in _config.Condition)
                Console.WriteLine(i + " ");
            Console.WriteLine("=====");
            foreach (string i in _config.BadData)
                Console.WriteLine(i + " ");
            Console.WriteLine("=====");
            foreach (string i in _config.Complete)
                Console.WriteLine(i + " ");
            Console.WriteLine("=====");



            /* TODO: temporary
            plan.AddTransaction(new Balance());
            plan.AddTransaction(new Withdrawal(_config));
            plan.AddTransaction(new Balance());
            */

            plans.Add(plan);
            return plans;
        }

        static void Main()
        {
            
        }
    }
}