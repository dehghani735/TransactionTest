using System;
using System.IO;
using System.Linq;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Helpers;
//using Xunit.Abstractions;

namespace TransactionTest
{
    public class LoadingAYamlStream
    {
        // private readonly ITestOutputHelper output;

        //   public LoadingAYamlStream(ITestOutputHelper output)
        //   {
        //       this.output = output;
        //   }

        /*[Sample(
            DisplayName = "Loading a YAML Stream",
            Description = "Explains how to load YAML using the representation model."
        )]*/


        public void ali()
        {
            // Setup the input
            var input = new StringReader(Document);

            // Load the stream
            var yaml = new YamlStream();
            yaml.Load(input);

            // Examine the stream
            var mapping =
                (YamlMappingNode)yaml.Documents[0].RootNode;

            foreach (var entry in mapping.Children)
            {
                Console.WriteLine(((YamlScalarNode)entry.Key).Value);
                //output.WriteLine(((YamlScalarNode)entry.Key).Value);
            }

            //Console.WriteLine(counter);

            // List all the items
             var items = (YamlSequenceNode)mapping.Children[new YamlScalarNode("Financial")];
            foreach (YamlScalarNode item in items)
            {
                Console.WriteLine(
                    item.ToString()
                );
                /*  output.WriteLine(
                      "{0}\t{1}",
                      item.Children[new YamlScalarNode("part_no")],
                      item.Children[new YamlScalarNode("descrip")]
                  ); */
            }

            var dataParameters = (YamlMappingNode)mapping.Children[new YamlScalarNode("Data-Parameters")];

            var cards = (YamlSequenceNode)dataParameters.Children[new YamlScalarNode("Cards")];
            foreach (YamlMappingNode data in cards)
            {
                Console.WriteLine(
                data.Children[new YamlScalarNode("Card_Type")]
                );
                /*  output.WriteLine(
                      "{0}\t{1}",
                      item.Children[new YamlScalarNode("part_no")],
                      item.Children[new YamlScalarNode("descrip")]
                  ); */
            }

            var amount = (YamlScalarNode)dataParameters.Children[new YamlScalarNode("Amount")];
            
            Console.WriteLine(amount);
            /*foreach (var entry in amount)
            {
                Console.WriteLine(((YamlScalarNode)entry.Value).Value);
                //output.WriteLine(((YamlScalarNode)entry.Key).Value);
            }*/

        }

        private const string Document = @"---
            Financial:
                - Withdrawal
                - Balance

            Non-Financial:
            
            Complete:
                - Balance
                - Authentication

            Condition:
                - Incorrect_PIN
                - Not_Enough_Cash

            Before-Checking:
                - Card_Status
                - Terminal_Status
                - Connection_Status

            After-Checking:
                - ATM_Cassettes
                - Card_Activity
                - Reduce_Balance

            Reverse:
                - Not_Withdrawal

            Bad-Data:
                - Amount
                - PIN
                - Track

            Data-Parameters:
                Cards:
                    - Card_Number: 5894631862983396
                      Card_Type: Refah
                      Track: 5894631511409724=99105061710399300020
                  
                    - Card_Number: 5894631862983396
                      Card_Type: Shetab
                      Track: 5894631511409724=99105061710399300020

                Amount: 200000
                

            date:        2007-08-06
            customer:
                given:   Dorothy
                family:  Gale

            items:
                - part_no:   A4786
                  descrip:   Water Bucket (Filled)
                  price:     1.47
                  quantity:  4

                - part_no:   E1628
                  descrip:   High Heeled ""Ruby"" Slippers
                  price:     100.27
                  quantity:  1

            bill-to:  &id001
                street: |
                        123 Tornado Alley
                        Suite 16
                city:   East Westville
                state:  KS

            ship-to:  *id001

            specialDelivery:  >
                Follow the Yellow Brick
                Road to the Emerald City.
                Pay no attention to the
                man behind the curtain.
...";
    }
}