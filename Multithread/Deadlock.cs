using System.Threading;

namespace WorstPractices.Multithread
{
    public class Deadlock
    {
        private readonly object firstLock = new object(); 
        private readonly object secondLock = new object();

        // deadlockSafe = true will use a method with the right lock order to avoid a deadlock
        public int Sum(bool deadlockSafe)
        {
            int? firstInt = null;
            int? secondInt = null;

            Thread firstThread = new (() => firstInt = SafeFirstMethod());
            Thread secondThread = new (() =>
                secondInt = deadlockSafe
                ? SafeSecondMethod()
                : UnsafeSecondMethod());
            
            firstThread.Start();
            secondThread.Start();

            firstThread.Join();
            secondThread.Join();

            return (firstInt ?? 0) + (secondInt ?? 0);
        }

        private int SafeFirstMethod()
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

        private int UnsafeSecondMethod()
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

        private int SafeSecondMethod()
        {
            lock (firstLock)
            {
                Thread.Sleep(1100);
                lock (secondLock)
                {
                    return 2;
                }
            }
        }
    }
}