using System;

namespace TransactionTest
{
    public class TransactionConfig
    {
        private Card _card;
        private string _amount;

        public TransactionConfig()
        {
            _amount = "200000";
        }

        public TransactionConfig(Card card) : this()
        {
            _card = card;
        }

        public TransactionConfig(Card card, string pinBufferA) : this(card)
        {
            _card.PinBufferA = pinBufferA; // set the incorrect pin
        }

        public Card Card
        {
            get { return _card; }
        }

        public string Amount
        {
            get { return _amount; }
        }
        
        static void Main()
        {
          /*  Console.WriteLine("ali");
            TransactionConfig tc = new TransactionConfig();
            Console.WriteLine(tc.V + " " + tc.X + " " + tc.Amount);

            TransactionConfig tc2 = new TransactionConfig("7890");
            Console.WriteLine(tc2.V + " " + tc2.X + " " + tc2.Amount);
            */
        }
    }
}