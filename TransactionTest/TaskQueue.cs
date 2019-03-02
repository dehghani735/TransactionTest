using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TransactionTest
{
    public static class TaskQueue
    {
        private static int _threadCount = 0;
        private static ConcurrentQueue<Plan> _queue = new ConcurrentQueue<Plan>();
        private static BlockingCollection<Plan> _blocking = new BlockingCollection<Plan>();
        private static List<Thread> _dequeueThreads = new List<Thread>(100);

        public static void Enqueue(Plan plan)
        {
            if (plan == null)
            {
                throw new ArgumentNullException("task is null");
            }
            _queue.Enqueue(plan);
            _blocking.Add(plan);
            //_queue.TryDequeue()
        }

        public static void Dequeue(int workers)
        {
            for (int i = 0; i < workers; i++)
            {
                var worker = new Thread(new ThreadStart(DequeueThreadFunc));
                worker.IsBackground = true;
                worker.Name = Interlocked.Increment(ref _threadCount).ToString();
                _dequeueThreads.Add(worker);
                worker.Start();
            }
        }

        public static void DequeueThreadFunc()
        {
            Plan plan;
            //Thread.Sleep(5000);
            //Console.WriteLine("Thread Started!");
            while (true)
            {
                if (_blocking.IsCompleted)
                {
                   // Thread.Sleep(100);
                }
                else if (_blocking.TryTake(out plan))
                {
                    plan.Process();
                    //Thread.Sleep(5000);
                }
            }
        }

        public static void Main()
        {
            for (int i = 0; i < 50; i++)
            {
                TaskQueue.Enqueue(new ConditionBasedPlan("ali", new Network(), new TransactionConfig()));
            }
            TaskQueue.Dequeue(50);
        }
    }
}
