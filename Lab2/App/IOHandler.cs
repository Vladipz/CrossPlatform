using System.Globalization;

namespace App
{
    public static class IOHandler
    {
        private const string InputFileName = "INPUT.TXT";

        private const string OutputFileName = "OUTPUT.TXT";

        public static (int n, double[] arr) ReadData()
        {
            if (!File.Exists(InputFileName))
            {
                throw new FileNotFoundException($"Input file \"{InputFileName}\" not found.");
            }

            var lines = File.ReadAllLines(InputFileName)
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

        public static void WriteResult(double result)
        {
            var resultString = result.ToString(CultureInfo.InvariantCulture);
            File.WriteAllText(OutputFileName, resultString);
        }
    }
}
