using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorstPractices
{
    [TestClass]
    public class RaceConditionTests
    {
        [TestMethod]
        public void RunMultiThread_Unsafe_ExpectedValuesAreDifferentToActualValues()
        {
            var result = new RaceConditions()
                .RunMultiThread(safe: false);
            
            Assert.AreNotEqual(
                notExpected: string.Join(',', result.Value.expected),
                actual: string.Join(',', result.Value.real));
        }

        [TestMethod]
        public void RunMultiThread_Safe_ExpectedValuesAreEqualToActualValues()
        {
            var result = new RaceConditions()
                .RunMultiThread(safe: true);
            
            Assert.AreEqual(
                expected: string.Join(',', result.Value.expected),
                actual: string.Join(',', result.Value.real));
        }
    }
}
