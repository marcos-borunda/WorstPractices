using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorstPractices
{
    [TestClass]
    public class StringConcatenationTests
    {
        [TestMethod]
        public void TestingStringConcatenation_TakesMoreThan100Miliseconds()
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            StringConcatenation.ConcatenatingUsingString();

            stopWatch.Stop();

            Assert.IsTrue(stopWatch.Elapsed.Milliseconds > 100, $"Elapsed: {stopWatch.Elapsed.Milliseconds}"); 
        }

        [TestMethod]
        public void TestingBuilderStringConcatenation_TakesLessThan5Miliseconds()
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            StringConcatenation.ConcatenatingUsingStringBuilder();

            stopWatch.Stop();

            Assert.IsTrue(stopWatch.Elapsed.Milliseconds < 5, $"Elapsed: {stopWatch.Elapsed.Milliseconds}"); 
        }
    }
}