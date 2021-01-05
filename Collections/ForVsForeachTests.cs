using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorstPractices.Collections
{
    [TestClass]
    public class ForVsForeachTests
    {
        [TestMethod]
        public void ForeachIsFasterThanFor()
        {
            ForVsForeach forVsForeach = new();

            long foreachMiliseconds = forVsForeach.LoopEllapsedMilliseconds(runForeach: true);
            long forMiliseconds = forVsForeach.LoopEllapsedMilliseconds(runForeach: false);

            // The result is false when we loop through more than 1,000,000,000
            Assert.IsTrue(foreachMiliseconds > forMiliseconds);
        }
    }
}