using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TransactionTest
{
    public class BackgroundWorkerSample
    {
        private BlockingCollection<Plan> _queue = new BlockingCollection<Plan>();
        //private Dictionary<string, BackgroundWorker> _workers = new Dictionary<string, BackgroundWorker>();
        private BackgroundWorker bg_worker = new BackgroundWorker();
        public static bool finished = false;

        public BackgroundWorkerSample()
        {
            bg_worker.WorkerReportsProgress = true;
            bg_worker.WorkerSupportsCancellation = true;

            bg_worker.DoWork += bg_DoWork;
            bg_worker.RunWorkerCompleted += Bg_worker_RunWorkerCompleted;
            bg_worker.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
        }

        private void Bg_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            finished = true;

            if (e.Cancelled)
                Console.WriteLine("You canceled!");
            else if (e.Error != null)
                Console.WriteLine("Worker exception: " + e.Error.ToString());
            else
                Console.WriteLine("Complete: " + e.Result);      // from DoWork
        }

        public void Enqueue(Plan plan)
        {
            if (plan == null)
            {
                throw new ArgumentNullException("task is null");
            }
            _queue.Add(plan);
        }

        public void Dequeue(int num)
        {
            Console.WriteLine("salam");
            bg_worker.RunWorkerAsync(100);
            //bg_worker.IsBusy = ;
            while(!finished)
                Thread.Sleep(1000);
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            /*  for (int i = 0; i < _queue.Count; i++)
              {
                  if (!_queue.IsCompleted)
                  {
                      //_queue.Take().Process();
                      bg_worker.ReportProgress(i);
                  }
              }*/

            int max = (int)e.Argument;
            int result = 0;
            for (int i = 0; i < max; i++)
            {
                int progressPercentage = Convert.ToInt32(((double)i / max) * 100);
                if (i % 42 == 0)
                {
                    result++;
                    (sender as BackgroundWorker).ReportProgress(progressPercentage, i);
                }
                else
                    (sender as BackgroundWorker).ReportProgress(progressPercentage);
                System.Threading.Thread.Sleep(1);

            }
            e.Result = 400;
            Console.WriteLine("thread started: ");
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine("Reached " + e.ProgressPercentage + "%");
        }

        public static void Main()
        {
            BackgroundWorkerSample bg = new BackgroundWorkerSample();
            /*for (int i = 0; i < 50; i++)
            {
                bg.Enqueue(new ConditionBasedPlan("ali", new Network(), new TransactionConfig()));
            }*/
            bg.Dequeue(4);
        }
    }
}
