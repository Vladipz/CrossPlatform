using System.Globalization;

namespace ClassLib
{
    public static class SecondLab
    {
        public static void Execute(string inputFilePath, string outputFilePath)
        {
            int n;
            double[]? arr;
            try
            {
                (n, arr) = ReadData(inputFilePath);
                Validator.ValidateDecimalNumbers(arr, 6);
                Validator.ValidateN(n);
                Validator.ValidateArrayRange(arr);
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
                WriteResult(result, outputFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error during calculation: {e.Message}");
                return;
            }

            try
            {
                WriteResult(result, outputFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error during writing result: {e.Message}");
            }


        }

        public static (int n, double[] arr) ReadData(string inputFilePath)
        {
            if (!File.Exists(inputFilePath))
            {
                throw new FileNotFoundException($"Input file \"{inputFilePath}\" not found.");
            }

            var lines = File.ReadAllLines(inputFilePath)
              .Select(static line => line.Trim())
              .Where(static line => !string.IsNullOrEmpty(line))
              .ToList();

            if (lines.Count == 0)
            {
                throw new InvalidOperationException("Input file is empty.");
            }

            if (lines.Count != 2)
            {
                throw new InvalidOperationException("Input file does not contain two lines.");
            }

            if (!int.TryParse(lines[0], out var n))
            {
                throw new InvalidOperationException("First line of the input file does not contain an integer.");
            }

            var arr = lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(static part => double.Parse(part, CultureInfo.InvariantCulture))
              .ToArray();

            return arr.Length != n
                ? throw new InvalidOperationException("Number of elements in the second line does not match the first line.")
                : (n, arr);
        }

        public static void WriteResult(double result, string outputFilePath)
        {
            var resultString = result.ToString(CultureInfo.InvariantCulture);
            File.WriteAllText(outputFilePath, resultString);
        }

        public static class Solution
        {
            public static double FindProbability(double[] arr, int n)
            {
                ValidateArray(arr, n);

                double prob = 1.0;
                for (int i = 0; i < n; i++)
                {
                    prob = (prob * arr[i]) + ((1 - arr[i]) * (1 - prob));
                }
                return prob;
            }

            private static void ValidateArray(double[] arr, int n)
            {
                if (arr == null)
                {
                    throw new ArgumentNullException(nameof(arr), "Array cannot be null.");
                }
                if (arr.Length != n)
                {
                    throw new InvalidOperationException("Number of elements in the second line does not match the first line.");
                }
            }
        }
    }
}
