using System.Text.RegularExpressions;

namespace dotnet_practice10_26
{
    public class Split
    {
        public static string CamelCase(string input)
        {
            return Regex.Replace(input, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
        }
    }
}