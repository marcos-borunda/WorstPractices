using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorstPractices.Multithread
{
    [TestClass]
    public class DeadlockTests
    {
        [Ignore] // Ignoring this test to avoid deadlock
        [TestMethod]
        public void Unsafe_Generates_DeadLock()
        {
            Assert.AreEqual(3, new Deadlock().Sum(deadlockSafe: false));
        }

        [TestMethod]
        public void Safe_Avoids_DeadLock()
        {
            Assert.AreEqual(3, new Deadlock().Sum(deadlockSafe: true));
        }
    }
}