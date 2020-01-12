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

		public PlanFactory planFactory;
		public Form4()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			/*
			// Create a new ListView control.
			//ListView listView1 = new ListView();
			listView1.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));

			// Set the view to show details.
			listView1.View = View.Details;
			// Allow the user to edit item text.
			listView1.LabelEdit = true;
			// Allow the user to rearrange columns.
			listView1.AllowColumnReorder = true;
			// Display check boxes.
			listView1.CheckBoxes = true;
			// Select the item and subitems when selection is made.
			listView1.FullRowSelect = true;
			// Display grid lines.
			listView1.GridLines = true;
			// Sort the items in the list in ascending order.
			listView1.Sorting = SortOrder.Ascending;

			// Create three items and three sets of subitems for each item.
			ListViewItem item1 = new ListViewItem("item1", 0);
			// Place a check mark next to the item.
			item1.Checked = true;
			item1.SubItems.Add("1");
			item1.SubItems.Add("2");
			item1.SubItems.Add("3");
			item1.BackColor = Color.Red;

			ListViewItem item2 = new ListViewItem("item2", 1);
			item2.SubItems.Add("4");
			item2.SubItems.Add("5");
			item2.SubItems.Add("6");
			ListViewItem item3 = new ListViewItem("item3", 0);
			// Place a check mark next to the item.
			item3.Checked = true;
			item3.SubItems.Add("7");
			item3.SubItems.Add("8");
			item3.SubItems.Add("9");

			// Create columns for the items and subitems.
			// Width of -2 indicates auto-size.
			listView1.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
			listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
			listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
			listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center);

			//Add the items to the ListView.
			listView1.Items.AddRange(new ListViewItem[] { item1, item2, item3 });
			listView1.Items.Add("salam");
			// Create two ImageList objects.
		 /* ImageList imageListSmall = new ImageList();
			ImageList imageListLarge = new ImageList();

			// Initialize the ImageList objects with bitmaps.
			imageListSmall.Images.Add(Bitmap.FromFile("C:\\MySmallImage1.bmp"));
			imageListSmall.Images.Add(Bitmap.FromFile("C:\\MySmallImage2.bmp"));
			imageListLarge.Images.Add(Bitmap.FromFile("C:\\MyLargeImage1.bmp"));
			imageListLarge.Images.Add(Bitmap.FromFile("C:\\MyLargeImage2.bmp"));

			//Assign the ImageList objects to the ListView.
			listView1.LargeImageList = imageListLarge;
			listView1.SmallImageList = imageListSmall;

			// Add the ListView to the control collection.
			this.Controls.Add(listView1);
			*/



			//listView1.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));

			// Set the view to show details.
			listView1.View = View.Details;
			// Allow the user to edit item text.
			listView1.LabelEdit = true;
			// Allow the user to rearrange columns.
			listView1.AllowColumnReorder = true;
			// Display check boxes.
			listView1.CheckBoxes = true;
			// Select the item and subitems when selection is made.
			listView1.FullRowSelect = true;
			// Display grid lines.
			listView1.GridLines = true;
			// Sort the items in the list in ascending order.
			listView1.Sorting = SortOrder.Ascending;

			// Create columns for the items and subitems.
			// Width of -2 indicates auto-size.
			listView1.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
			//listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
			//listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
			//listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center);


			var config = new Config(this);
			config.ReadFile();
			config.Parse();

			planFactory = new PlanFactory(config);

			planFactory.PlanAdded += this.OnItemAdded;

			// TODO: generate plans is incomplete
			planFactory.GeneratePlans();
		}

		public void OnTransactionChangeStatus(object source, TransactionEventArgs args)
		{
      ListViewItem listViewItem = listView1.FindItemWithText("~Enough_Cash ~Amount Test1");



      string[] conditionList = condition.TrimStart(' ').TrimEnd(' ').Split(' ');
      HashSet<string> conditionSet = new HashSet<string>();

      foreach (var lst in conditionList)
      {
        conditionSet.Add(lst);
      }


      switch (args.EventType)
			{
				case TransactionEventArgs.eStatus.Passed:
					textBox1.Text = "Passed";
					Console.WriteLine("event Passed handled");
					//this.ShowDialog("ddd");
					break;
				case TransactionEventArgs.eStatus.Failed:
					textBox1.Text = "Failed";
										listViewItem.BackColor = Color.Red;
										// streamWriter.WriteLine("====================================================================");
										break;
				default:
					break;
			}
		}

		public void OnItemAdded(object source, PlanEventArgs args)
		{
			/*var lvi = new ListViewItem("salam");
			lvi.Tag = "salam";
			listView1.Items.Add(lvi);*/


			// Create three items and three sets of subitems for each item.
			ListViewItem item1 = new ListViewItem(args.EventMessage);
			// Place a check mark next to the item.
			//item1.Checked = true;
			//item1.SubItems.Add("1");
			//item1.SubItems.Add("2");
			//item1.SubItems.Add("3");
			item1.BackColor = Color.LightYellow;

			//ListViewItem item2 = new ListViewItem("item2", 1);
			//item2.SubItems.Add("4");
			//item2.SubItems.Add("5");
			//item2.SubItems.Add("6");
			//ListViewItem item3 = new ListViewItem("item3", 0);
			//// Place a check mark next to the item.
			//item3.Checked = true;
			//item3.SubItems.Add("7");
			//item3.SubItems.Add("8");
			//item3.SubItems.Add("9");

			//// Create columns for the items and subitems.
			//// Width of -2 indicates auto-size.
			//listView1.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
			//listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
			//listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
			//listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center);

			//Add the items to the ListView.
			//listView1.Items.AddRange(new ListViewItem[] { item1});
			//listView1.Items.Add("salam");
			listView1.Items.Add(item1);







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

		private void button2_Click(object sender, EventArgs e)
		{
			 //take this block for running the test cases
			Reporter.Log(System.DateTime.Now.ToString());

			planFactory.ProcessPendingPlans();
		}
	}
}
