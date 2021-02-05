using System;

namespace ASD_lab1
{
    public static class Extentions
    {
        public static void SafeRunning(Action action, string errorMessage = "Error")
        {
            do
            {
                try
                {
                    action?.Invoke();
                    break;
                }
                catch
                {
                    Console.WriteLine(errorMessage);
                }
            } while (true);
        }
    }
}