using System;
using System.Diagnostics;

namespace WorstPractices.Collections
{
    public class ForVsForeach
    {
        const long ArraySize = 1_000_000;

        private readonly int[] _largeArray = new int[ArraySize];

        public ForVsForeach()
        {
            var random = new Random();
            for (int i = 0; i < ArraySize; ++i)
                _largeArray[i] = random.Next(100);
        }

        public long LoopEllapsedMilliseconds(bool runForeach)
        {
            long sum = 0;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            if (runForeach)
            {
                foreach (var number in _largeArray)
                    sum += number;
            }
            else
            {
                for (int i = 0; i < ArraySize; i++)
                    sum += _largeArray[i];
            }

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }
    }
}