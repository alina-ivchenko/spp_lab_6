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
        //поток, управляющий потоками-рабочими
        private Thread localCycleThread;
        //для lock'a потоков
        private object sync1 = new object();
        //для тасков
        private object sync2 = new object();
        //уведомление о добавлении задачи
        private static AutoResetEvent eTimeoutOrNewObj = new AutoResetEvent(true);
        //список потоков
        private Dictionary<int, Thread> Threads = new Dictionary<int, Thread>();
        //очередь заданий
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
            if (amountOfThreads > 1)
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
            if (amountOfThreads >= min)
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
                //достигли максимального количества потоков и они все заняты
                if ((Threads.Count() == max) && (!isWaiting))
                {
                    Log.Show("!!! Was not added");
                    return false;
                }
                else
                {
                    queueOfTasks.Enqueue(addedTask);
                    //уведомляем о задании
                    eTimeoutOrNewObj.Set();
                    Log.WriteToLogFile("task was added");
                }
            }
            
            
            return true;
        }

        private void ProvideMultiThreading()
        {
            //контролируется создание потоков
            while (true)
            {
                if ((GetCurrAmountOfThreads() < min) || (queueOfTasks.Count > 1 && GetCurrAmountOfThreads() < max))
                {
                    //создаем поток
                    var tempThread = new Thread(Exec);
                    tempThread.Start();
                    //фоновый
                    tempThread.IsBackground = true;
                    Log.WriteToLogFile(tempThread.ManagedThreadId + ": was started");
                    lock (sync1)
                    {
                        //добавляем поток в пул
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

                //проверяем, достали ли задание из очереди
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
                            isStoppedByEvent = eTimeoutOrNewObj.WaitOne(5000);//ждем 5 секунд, если заданий не получил, убиваем
                        else
                            isStoppedByEvent = eTimeoutOrNewObj.WaitOne();
                        isWaiting = false;
                        //убиваем
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
                            //изымаем из очереди задание
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

