using System.Text;

namespace WorstPractices
{
    public static class StringConcatenation
    {
        public static string ConcatenatingUsingString()
        {
            var longString = string.Empty;

            for (var i = 0; i < 50_000 ; i++)
                longString += "0123456789";
            
            return longString;
        }

        public static string ConcatenatingUsingStringBuilder()
        {
            var longString = new StringBuilder();

            for (var i = 0; i < 50_000 ; i++)
                longString.Append("0123456789");
            
            return longString.ToString();
        }
    }
}