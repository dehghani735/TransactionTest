using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Helpers;

namespace TransactionTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new Form3();
            myForm.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*ProcessStartInfo processStartInfo = new ProcessStartInfo("C:\\Program Files\\Java\\jdk1.8.0_172\\bin\\java.exe");
            processStartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            processStartInfo.Arguments = "HelloWorld";
            processStartInfo.UseShellExecute = false;
            processStartInfo.ErrorDialog = false;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;

            Process process = new Process();
            process.StartInfo = processStartInfo;
            bool processStarted = process.Start();

            StreamWriter inputWriter = process.StandardInput;
            StreamReader outputReader = process.StandardOutput;
            StreamReader errorReader = process.StandardError;

            String error_string = errorReader.ReadToEnd();
            String output_string = outputReader.ReadToEnd();
            Console.WriteLine(output_string);
            Console.Write("Press any key to continue.....\n");
            System.ConsoleKeyInfo KInfo = Console.ReadKey(true);
          //  Win32.FreeConsole();
            process.Close();
            */

            




            System.Diagnostics.Process clientProcess = new Process();
            clientProcess.StartInfo.FileName = "java.exe";
            clientProcess.StartInfo.Arguments = @"-jar " + "C:\\Users\\m.dehghani\\Desktop\\JarInCSharp\\TransactionTest.jar";
            clientProcess.Start();
            clientProcess.WaitForExit();
            //clientProcess.WaitForInputIdle();
            //int code = clientProcess.ExitCode != 0)
            //Close();  
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}