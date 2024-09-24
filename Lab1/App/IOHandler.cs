namespace App
{
    public static class IOHandler
    {
        private const string InputFileName = "INPUT.TXT";
        private const string OutputFileName = "OUTPUT.TXT";
        private const int MaxValue = 1000; // Обмеження на W і H

        public static (int x, int y) ReadCoordinates()
        {
            if (!File.Exists(InputFileName))
            {
                throw new FileNotFoundException("Input file not found.");
            }

            // select the coordinates from the first line of the input file
            var lines = File.ReadAllLines(InputFileName)
              .Select(static line => line.Trim())
              .Where(static line => !string.IsNullOrEmpty(line))
              .ToList();

            if (lines.Count == 0)
            {
                throw new InvalidOperationException("Input file is empty.");
            }

            if (lines.Count != 1)
            {
                throw new InvalidOperationException("Input file contains more than one line.");
            }

            var parts = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                throw new InvalidOperationException("Input file does not contain two integers.");
            }

            if (!int.TryParse(parts[0], out var x) || !int.TryParse(parts[1], out var y))
            {
                throw new InvalidOperationException("Input file contains invalid integers.");
            }
            // Перевірка обмежень на W і H
            if (x < 1 || x > MaxValue || y < 1 || y > MaxValue)
            {
                throw new InvalidOperationException($"Input values must be between 1 and {MaxValue}.");
            }
            return (x, y);
        }

        public static void WriteResult(int result)
        {
            File.WriteAllText(OutputFileName, result.ToString());
        }
    }
}
