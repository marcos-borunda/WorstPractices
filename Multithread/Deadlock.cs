using System.Threading;

namespace WorstPractices.Multithread
{
    public class Deadlock
    {
        private readonly object firstLock = new object(); 
        private readonly object secondLock = new object();

        public int DeadlockSum()
        {
            int? firstInt = null;
            int? secondInt = null;

            Thread firstThread = new (() => firstInt = FirstMethod());
            Thread secondThread = new (() => secondInt = SecondMethod());
            
            firstThread.Start();
            secondThread.Start();

            firstThread.Join();
            secondThread.Join();

            return (firstInt ?? 0) + (secondInt ?? 0);
        }

        private int FirstMethod()
        {
            lock (firstLock)
            {
                Thread.Sleep(1000);
                lock (secondLock)
                {
                    return 1;
                }
            }
        }

        private int SecondMethod()
        {
            lock (secondLock)
            {
                Thread.Sleep(1100);
                lock (firstLock)
                {
                    return 2;
                }
            }
        }
    }
}