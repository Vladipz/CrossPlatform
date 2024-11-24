using System.Globalization;

namespace ClassLib
{
    public static class SecondLab
    {
        public static string Execute(string text)
        {
            int n;
            double[]? arr;
            try
            {
                (n, arr) = ReadDataFromText(text);
                Validator.ValidateDecimalNumbers(arr, 6);
                Validator.ValidateN(n);
                Validator.ValidateArrayRange(arr);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Invalid input: {e.Message}");
                return $"Invalid input: {e.Message}";
            }

            double result;
            try
            {
                result = Solution.FindProbability(arr, n);
                result = Math.Round(result, 6);
                Console.WriteLine("Propability of truth: " + result);
                return $"Propability of truth: {result}";
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error during calculation: {e.Message}");
                return $"Error during calculation: {e.Message}";
            }
        }

        public static (int n, double[] arr) ReadDataFromText(string inputText)
        {
            // Розділяємо введений текст на рядки
            var lines = inputText.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(static line => line.Trim())
                                 .Where(static line => !string.IsNullOrEmpty(line))
                                 .ToList();

            // Перевірка, чи є хоча б два рядки
            if (lines.Count == 0)
            {
                throw new InvalidOperationException("Input is empty.");
            }

            if (lines.Count != 2)
            {
                throw new InvalidOperationException("Input should contain exactly two lines.");
            }

            // Перший рядок — це число n
            if (!int.TryParse(lines[0], out var n))
            {
                throw new InvalidOperationException("First line does not contain a valid integer.");
            }

            // Другий рядок — це масив чисел
            var arr = lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                              .Select(static part => double.Parse(part, CultureInfo.InvariantCulture))
                              .ToArray();

            // Перевірка відповідності кількості елементів
            if (arr.Length != n)
            {
                throw new InvalidOperationException("The number of elements in the second line does not match the number specified in the first line.");
            }

            return (n, arr);
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
