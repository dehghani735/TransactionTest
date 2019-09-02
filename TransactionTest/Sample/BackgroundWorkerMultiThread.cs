using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TransactionTest
{
    class BackgroundWorkerMultiThread
    {
        private List<BackgroundWorker> _workers = new List<BackgroundWorker>();
        private List<List<string>> _list = new List<List<string>>();

        private int total_workers = 4;
        private int completed_workers = 0;

        private List<string> l1 = new List<string>();
        private List<string> l2 = new List<string>();
        private List<string> l3 = new List<string>();
        private List<string> l4 = new List<string>();

        public BackgroundWorkerMultiThread()
        {

            for (int i = 1; i < 4; i++)
            {
                l1.Add(i + "1");
            }
            for (int i = 1; i < 4; i++)
            {
                l2.Add(i + "2");
            }
            for (int i = 1; i < 4; i++)
            {
                l3.Add(i + "3");
            }
            for (int i = 1; i < 4; i++)
            {
                l4.Add(i + "4");
            }
            _list.Add(l1);
            _list.Add(l2);
            _list.Add(l3);
            _list.Add(l4);
        }

        private void Process()
        {
            for (int i = 0; i < 4; i++)
            {
                BackgroundWorker bw = new BackgroundWorker();
                _workers.Add(bw);
                _workers[i].DoWork += bg_DoWork;
                _workers[i].RunWorkerCompleted += bg_runWorker_Completed;
                _workers[i].RunWorkerAsync(_list[i]);
            }

            while (total_workers != completed_workers)
                Thread.Sleep(1000);

            //Thread.Sleep(4000);
        }

        private void bg_runWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();

            completed_workers++;

            // _workers.re
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            //throw new NotImplementedException();
            List<string> _lst = (List<string>) e.Argument;
            foreach (var element in _lst)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine("thread started!");
        }

        public static void Main()
        {
            BackgroundWorkerMultiThread bg = new BackgroundWorkerMultiThread();

            bg.Process();
        }
    }
}
