using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorstPractices.Async
{
    [TestClass]
    public class AsyncVoidReturnTests
    {
        [TestMethod]
        public async Task HandledException_ReturnsTrue()
        {
            // If we change catchable to false the exception won't be catched
            // not even by from MsTest's ExpectException
            var result = await AsyncVoidReturn
                .DidYouCatchTheExceptionAsync(catchable: true);
                
            Assert.IsTrue(result);
        }
    }
}