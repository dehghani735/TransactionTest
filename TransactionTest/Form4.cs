using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;

namespace TransactionTest
{
    public partial class Form4 : Form
    {

        public PlanFactory planFactory;
        public int numberOfPlans;
        public int numberOfPassed;
        public int numberOfFailed;

        public Form4()
        {
            InitializeComponent();
            numberOfPlans = 0;
            numberOfPassed = 0;
            numberOfFailed = 0;
            textBox1.Text = "0";
            textBox2.Text = "0";

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
            //listView1.Sorting = SortOrder.Ascending;

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            listView1.Columns.Add("Number", -2, HorizontalAlignment.Center);
            listView1.Columns.Add("Plan Description", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Error Reason", -2, HorizontalAlignment.Left);
        }

        private void CreatePlans_Click(object sender, EventArgs e)
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
            var description = args.EventMessage.Description.Split(',')[0] + ": " + args.EventMessage.Description.Split(',')[1];
            ListViewItem listViewItem = listView1.FindItemWithText(description);

            switch (args.EventType)
            {
                case TransactionEventArgs.eStatus.Passed:
                    //textBox1.Text = "Passed";
                    //Console.WriteLine("event Passed handled");
                    listViewItem.BackColor = Color.LightGreen;
                    textBox2.Text = (++numberOfPassed).ToString();
                    //this.ShowDialog("ddd");
                    break;
                case TransactionEventArgs.eStatus.Failed:
                    //textBox1.Text = "Failed";
                    listViewItem.BackColor = Color.MediumVioletRed;
                    listViewItem.SubItems.Add(args.Message);
                    textBox1.Text = (++numberOfFailed).ToString();
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

            //ListViewItem item2 = new ListViewItem("item2", 1);
            //item2.SubItems.Add("4");
            //item2.SubItems.Add("5");
            //item2.SubItems.Add("6");

            // Create three items and three sets of subitems for each item.

            ListViewItem item1 = new ListViewItem((++numberOfPlans).ToString());
            //ListViewItem item1 = new ListViewItem(args.EventMessage);
            // Place a check mark next to the item.
            item1.Checked = true;
            item1.SubItems.Add(args.EventMessage);
            //item1.SubItems.Add("error");
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

        private void Run_Click(object sender, EventArgs e)
        {

            //var selected = listView1.CheckedIndices;
            List<int> selected = new List<int>();

            for (int j = 0; j < listView1.CheckedIndices.Count; j++)
            {
                selected.Add(listView1.CheckedIndices[j]);
            }

            List<int> totalList = new List<int>();
            List<int> finalList = new List<int>();

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                totalList.Add(i);
            }

            //for (int i = 0; i < totalList.Count; i++)
            //{
            //  for (int j = 0; j < listView1.CheckedIndices.Count; j++)
            //  {
            //    if (totalList[i] != listView1.CheckedIndices[j])
            //    {
            //      finalList.Add(totalList[i]);
            //    }
            //  }
            //}

            var difference = totalList.Except(selected);

            foreach (int indice in difference.OrderByDescending(v => v))
            {
                planFactory._plans.RemoveAt(indice);
            }

            //foreach (int s in listView1.CheckedIndices)
            //{
            //  planFactory._plans.RemoveAt(s);
            //}

            //take this block for running the test cases
            Reporter.Log(System.DateTime.Now.ToString());

            planFactory.ProcessPendingPlans();
        }

        private void ExportExcel_Click(object sender, EventArgs e)
        {
            string filePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\..\..\ReportCSV.csv";

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                //csv.Write
                //csv.WriteRecord("ggg");

                //csv.WriteHeader();    

                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    csv.WriteField(listView1.Items[i]);
                    csv.WriteField(listView1.Items[i].SubItems[0]);
                    csv.WriteField(listView1.Items[i].SubItems[1]);
                    csv.WriteField(listView1.Items[i].SubItems[2]);
                    csv.NextRecord();
                }

                //csv.WriteField("sss");
                //csv.WriteField("sss");
                //csv.WriteField("sss");
                //csv.WriteField("sss");
                //csv.NextRecord();
                //csv.WriteField("ttt");
                //csv.WriteField("ttt");
                //csv.WriteField("ttt");
                //csv.WriteField("ttt");
                //csv.NextRecord();
            }
        }

        private void ClearPlans_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            planFactory._plans.Clear();
            numberOfPlans = 0;
            numberOfFailed = 0;
            numberOfPassed = 0;
            textBox1.Text = "0";
            textBox2.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].Checked = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].Checked = false;
            }
        }
    }
}
