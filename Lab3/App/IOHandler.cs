using System.Globalization;

namespace App
{
    public static class IOHandler
    {
        private const string InputFileName = "INPUT.TXT";
        private const string OutputFileName = "OUTPUT.TXT";


        public static (int n, List<int> numbersOfDepartments, List<int> connections) ReadTree()
        {
            if (!File.Exists(InputFileName))
            {
                string fullPath = Path.GetFullPath(InputFileName);
                throw new FileNotFoundException($"Input file not found. Please place the file at: {fullPath}");
            }

            var lines = File.ReadAllLines(InputFileName)
              .Select(static line => line.Trim())
              .Where(static line => !string.IsNullOrEmpty(line))
              .ToList();

            if (lines.Count == 0)
            {
                throw new InvalidOperationException("Input file is empty.");
            }

            if (lines.Count != 3)
            {
                throw new InvalidOperationException("Input file should contain 3 lines.");
            }

            var parts = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 1)
            {
                throw new InvalidOperationException("Input file does not contain two integers.");
            }

            // Зчитування кількості відділів (перший рядок)
            if (!int.TryParse(lines[0], out int n) || n <= 0 || n > 30000)
            {
                throw new InvalidOperationException("Firts line must contain natural number (1 < n <= 30000).");
            }



            // Зчитування двох номерів підозрюваних відділів (другий рядок)
            var numbersOfDepartments = lines[1].Split()
                .Select(num =>
                {
                    if (!int.TryParse(num, out int departmentNumber) || departmentNumber < 1 || departmentNumber > n)
                    {
                        throw new InvalidOperationException($"Incorrect department number: {num} in the second line.");
                    }
                    return departmentNumber;
                })
                .ToList();

            if (numbersOfDepartments.Count != 2)
            {
                throw new InvalidOperationException("Second line must contain two department numbers.");
            }


            // Зчитування батьківських відділів для всіх відділів, окрім кореневого (третій рядок)
            var connections = lines[2].Split()
                .Select(num =>
                {
                    if (!int.TryParse(num, out int parentNumber) || parentNumber < 1 || parentNumber >= n)
                    {
                        throw new InvalidOperationException($"Incorrect parent number: {num} in the third line.");
                    }
                    return parentNumber;
                })
                .ToList();


            if (connections.Count != n - 1)
            {
                throw new InvalidOperationException($"Third line must contain {n - 1} parent numbers.");
            }

            return (n, numbersOfDepartments, connections);

        }

        public static void WriteResult(int result)
        {
            File.WriteAllText(OutputFileName, result.ToString(CultureInfo.InvariantCulture));
        }
    }
}
