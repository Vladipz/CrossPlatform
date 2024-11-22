using System.Globalization;

namespace ClassLib
{
    public static class FirstLab
    {
        private const int MaxValue = 1000; // Обмеження на W і H
        public static string Execute(string text)
        {
            int x, y;
            try
            {
                (x, y) = ReadCoordinatesFromText(text);
                Console.WriteLine($"x: {x}, y: {y}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return $"Error reading coordinates: {e.Message}";
            }

            int countOfRectangles;
            try
            {
                countOfRectangles = GetCountOfRectangles(x, y);
                Console.WriteLine($"Count of rectangles: {countOfRectangles}");
                return countOfRectangles.ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return $"Error calculating count of rectangles: {e.Message}";
            }

        }

        private static int GetCountOfRectangles(int w, int h)
        {
            ValidateDimension(w, nameof(w));
            ValidateDimension(h, nameof(h));

            var count_x = CombinationsWithouRepetition((ulong)w);
            var count_y = CombinationsWithouRepetition((ulong)h);
            var result = count_x * count_y;
            return (int)result;
        }

        private static void ValidateDimension(int dimension, string paramName)
        {
            if (dimension < 1 || dimension > 1000)
            {
                throw new ArgumentOutOfRangeException(paramName, $"{paramName} must be between 1 and 1000.");
            }
        }

        private static ulong CombinationsWithouRepetition(ulong n)
        {
            return (n + 1) * n / 2;
        }


        private static (int x, int y) ReadCoordinatesFromText(string inputText)
        {
            if (string.IsNullOrWhiteSpace(inputText))
            {
                throw new InvalidOperationException("Input text is empty.");
            }

            // Очищаємо текст, видаляємо зайві пробіли та переносимо на нові рядки
            var lines = inputText.Split('\n')
                                 .Select(static line => line.Trim())
                                 .Where(static line => !string.IsNullOrEmpty(line))
                                 .ToList();

            if (lines.Count == 0)
            {
                throw new InvalidOperationException("Input text is empty.");
            }

            if (lines.Count != 1)
            {
                throw new InvalidOperationException("Input text contains more than one line.");
            }

            // Розділяємо значення по пробілу
            var parts = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                throw new InvalidOperationException("Input text does not contain two integers.");
            }

            if (!int.TryParse(parts[0], out var x) || !int.TryParse(parts[1], out var y))
            {
                throw new InvalidOperationException("Input text contains invalid integers.");
            }

            // Перевірка обмежень на x та y
            if (x < 1 || x > MaxValue || y < 1 || y > MaxValue)
            {
                throw new InvalidOperationException($"Input values must be between 1 and {MaxValue}.");
            }

            return (x, y);
        }
        private static void WriteResult(int result, string outputFilePath)
        {
            File.WriteAllText(outputFilePath, result.ToString(CultureInfo.InvariantCulture));
        }


    }
}
