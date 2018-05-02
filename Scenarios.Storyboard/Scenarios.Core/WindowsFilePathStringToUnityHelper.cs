namespace Scenarios.Core
{
    public static class WindowsFilePathStringToUnityHelper
    {
        public static string ConvertToUnityStyle(string input)
        {
            if (input == null)
            {
                return null;
            }

            return input.Replace("\\", "/");
        }
    }
}
