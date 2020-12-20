using System;
using System.Threading;

namespace WorstPractices.Multithread
{
    public class RaceConditions
    {
        const int SizeArray = 10;

        private readonly SharedValues _sharedValues = new SharedValues();
        private readonly object balanceLock = new object();

        public (int[] expected, int[] real)? RunMultiThread(bool safe)
        {
            (int[],int[])? values = null;

            Thread firstThread = new(() => values = safe
                ? SafeUpdateValue()
                : UnsafeUpdateValue());

            Thread secondThread = new(() => _ = safe
                ? SafeUpdateValue()
                : UnsafeUpdateValue());

            Thread thirdThread = new(() => _ = safe
                ? SafeUpdateValue()
                : UnsafeUpdateValue());

            secondThread.Start();
            thirdThread.Start();
            firstThread.Start();

            firstThread.Join();

            return values;
        }

        private (int[] expected, int[]real) UnsafeUpdateValue()
        {
            Random random = new();

            var expected = new int[SizeArray];
            var real = new int[SizeArray];

            for (var i = 0; i < SizeArray; i++)
            {
                var current = _sharedValues.MyValue;

                Thread.Sleep(random.Next(1,100));

                expected[i] = current + 1;

                real[i] = ++_sharedValues.MyValue;
            }

            return (expected, real);
        }

        private (int[] expected, int[]real)? SafeUpdateValue()
        {
            (int[], int[])? result = null;

            lock (balanceLock)
            {
                result = UnsafeUpdateValue();
            }

            return result;
        }
    }

    public class SharedValues
    {
        public int MyValue { get; set; } = 0;
    }
}