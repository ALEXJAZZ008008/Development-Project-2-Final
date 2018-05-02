namespace Scenarios.Core
{
    public static class UnityStringToWindowsStringHelper
    {
        public static string ConvertToWindowsFile(string input)
        {
            if (input == null)
            {
                return null;
            }

            return input.Replace("/", "\\");
        }
    }
}
