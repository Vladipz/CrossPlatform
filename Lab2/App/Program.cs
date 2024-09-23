namespace App
{
    internal static class Program
    {
        private static void Main()
        {
            int n;
            double[]? arr;
            try
            {
                (n, arr) = IOHandler.ReadData();
                Validator.ValidateDecimalNumbers(arr, 6);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Invalid input: {e.Message}");
                return;
            }

            double result;
            try
            {
                result = Solution.FindProbability(arr, n);
                result = Math.Round(result, 6);
                Console.WriteLine("Propability of truth: " + result);
                IOHandler.WriteResult(result);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error during calculation: {e.Message}");
                return;
            }

            try
            {
                IOHandler.WriteResult(result);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error during writing result: {e.Message}");
            }
        }
    }
}
