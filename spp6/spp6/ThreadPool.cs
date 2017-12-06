using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace spp6
{
    public class ThreadPool : IThreadRool
    {
        private int min;
        private int max;
        private bool isWaiting = false;
        private Thread localCycleThread;
        private object sync1 = new object();
        private object sync2 = new object();
        private static AutoResetEvent eTimeoutOrNewObj = new AutoResetEvent(true);
        private Dictionary<int, Thread> Threads = new Dictionary<int, Thread>();
        private Queue<TaskFunction> queueOfTasks = new Queue<TaskFunction>();
        public ThreadPool(int min = 2, int max = 5)
        {
            SetMinAmountOFThreads(min);
            SetMaxAmountOFThreads(max);
            localCycleThread = new Thread(ProvideMultiThreading);
            localCycleThread.IsBackground = true;
            Log.WriteToLogFile("Multithreading was started");
            localCycleThread.Start();
        }

        public void SetMinAmountOFThreads(int amountOfThreads)
        {
            if (min > 1)
            {
                min = amountOfThreads;
            }
            else
            {
                min = 2;
            }
        }

        public void SetMaxAmountOFThreads(int amountOfThreads)
        {
            if (max > min)
            {
                max = amountOfThreads;
            }
            else
            {
                max = 5;
            }
        }

        public bool AddTask(TaskFunction addedTask)
        {
            lock (sync1)
            {
                    if((Threads.Count() == max) && (!isWaiting))
                    {
                        Log.Show("!!! Was not added");
                        return false;
                    }
                    else
                    {
                        queueOfTasks.Enqueue(addedTask);           
                    }
            }
            Log.WriteToLogFile("task was added");
            eTimeoutOrNewObj.Set();
            return true;
        }

        private void ProvideMultiThreading()
        {
            //здесь должно контролироваться создание потоков
            while (true)
            {
                if ((GetCurrAmountOfThreads() < min) || (queueOfTasks.Count > 1 && GetCurrAmountOfThreads() < max))
                {
                    var tempThread = new Thread(Exec);
                    tempThread.Start();
                    tempThread.IsBackground = true;
                    Log.WriteToLogFile(tempThread.ManagedThreadId + ": was started");
                    lock (sync1)
                    {
                        Threads.Add(tempThread.ManagedThreadId, tempThread);
                    }
                }
                Thread.Sleep(500);
            }
        }

        private int GetCurrAmountOfThreads()
        {
            return Threads.Count;
        }

        private void Exec()
        {
            //здесь должно контролироваться выполнение задач
            bool isStoppedByEvent;
            TaskFunction currTask;
            do
            {
                currTask = null;
                lock (sync2)
                {
                    if (queueOfTasks.Count != 0)
                    {
                        currTask = queueOfTasks.Dequeue(); //уже потокобезопасная
                        Log.WriteToLogFile(Thread.CurrentThread.ManagedThreadId + ": Task dequeued");
                    }
                }

                if (currTask != null)
                {
                    currTask();
                    Log.WriteToLogFile(Thread.CurrentThread.ManagedThreadId + ": Task was proccessed");
                }
                else
                {
                    lock (sync2)
                    {
                        //ситуация, когда очередь пуста
                        eTimeoutOrNewObj.Reset();
                        isWaiting = true;
                        Log.WriteToLogFile(Thread.CurrentThread.ManagedThreadId + ": queue is empty. Wait");
                        if (GetCurrAmountOfThreads() > min)
                            isStoppedByEvent = eTimeoutOrNewObj.WaitOne(5000);
                        else
                            isStoppedByEvent = eTimeoutOrNewObj.WaitOne();
                        isWaiting = false;
                        if (!isStoppedByEvent)
                        {
                            //if (GetCurrAmountOfThreads() > min)
                            //{
                            Threads.Remove(Thread.CurrentThread.ManagedThreadId);
                            Log.WriteToLogFile(Thread.CurrentThread.ManagedThreadId + ": Stopped by timeout");
                            Thread.CurrentThread.Abort();
                            //}
                        }
                        else
                        {
                            if (queueOfTasks.Count() != 0)
                            {
                                currTask = queueOfTasks.Dequeue();
                                Log.WriteToLogFile(Thread.CurrentThread.ManagedThreadId + ": New Task was added. Stop Waiting");
                                currTask();
                                Log.WriteToLogFile(Thread.CurrentThread.ManagedThreadId + ": Task was proccessed");
                            }
                        }
                    }
                }
            }
            while (true);
        }
    }
}

