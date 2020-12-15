using System;
using System.Threading.Tasks;

namespace WorstPractices.Async
{
    public static class AsyncVoidReturn
    {
        public static async Task<bool> DidYouCatchTheExceptionAsync(bool catchable)
        {
            try
            {
                if (catchable)
                    await CatchableExceptionAsync();
                else
                    UncatchableExceptionAsync();
                
                // This line will never even be reached 
                return false;
            }
            catch(Exception)
            {
                return true;
            }
        }

        private static async void UncatchableExceptionAsync()
            => throw new Exception("No one will catch me");
        
        private static async Task CatchableExceptionAsync()
            => throw new Exception("Someone will catch me");
    }
}