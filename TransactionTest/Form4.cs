using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransactionTest
{
  public partial class Form4 : Form
  {
    public Form4()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      var config = new Config(this);
      config.ReadFile();
      config.Parse();

      var planFactory = new PlanFactory(config);

      planFactory.PlanAdded += this.OnItemAdded;

      // TODO: generate plans is incomplete
      planFactory.GeneratePlans();

      Reporter.Log(System.DateTime.Now.ToString());

      planFactory.ProcessPendingPlans();
    }

    public void OnTransactionChangeStatus(object source, TransactionEventArgs args)
    {
      switch (args.EventType)
      {
        case TransactionEventArgs.eStatus.Passed:
          textBox1.Text = "Passed";
          Console.WriteLine("event Passed handled");
          //this.ShowDialog("ddd");
          break;
        case TransactionEventArgs.eStatus.Failed:
          textBox1.Text = "Failed";
          // streamWriter.WriteLine("====================================================================");
          break;
        default:
          break;
      }

    }

    public void OnItemAdded(object source, PlanEventArgs args)
    {
      var lvi = new ListViewItem("salam");
      lvi.Tag = "salam";
      listView1.Items.Add(lvi);

      //switch (args.EventType)
      //{
      //  case TransactionEventArgs.eStatus.Passed:
      //    textBox1.Text = "Passed";
      //    Console.WriteLine("event Passed handled");
      //    //this.ShowDialog("ddd");
      //    break;
      //  case TransactionEventArgs.eStatus.Failed:
      //    textBox1.Text = "Failed";
      //    // streamWriter.WriteLine("====================================================================");
      //    break;
      //  default:
      //    break;
      //}
    }

    private void textBox1_TextChanged(object sender, EventArgs args)
    {
      /*switch (args.EventType)
      {
          case TransactionEventArgs.eStatus.Passed:
              textBox1.Text = "Passed";
              break;
          case TransactionEventArgs.eStatus.Failed:
              textBox1.Text = "Failed";
              //streamWriter.WriteLine("====================================================================");
              break;
          default:
              break;
      }*/
    }
  }
}
