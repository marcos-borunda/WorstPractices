using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorstPractices.Multithread
{
    [TestClass]
    public class DeadlockTests
    {
        [TestMethod]
        [Ignore] // Ignoring this test to avoid deadlock
        public void TestDeadLock()
        {
            Assert.AreEqual(3, new Deadlock().DeadlockSum());
        }
    }
}