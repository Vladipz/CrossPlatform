using System.Globalization;

namespace ClassLib
{
    public static class ThirdLab
    {

        public static string Execute(string text)
        {
            try
            {
                var (n, numbersOfDepartments, connections) = ReadTreeFromText(text);
                Console.WriteLine($"Count of departments: {n}");
                Console.WriteLine($"Suspected departments: {string.Join(" ", numbersOfDepartments)}");
                Console.WriteLine($"Connections: {string.Join(" ", connections)}");
                var lca = DepartmetnsService.Solve(n, numbersOfDepartments, connections);
                return lca.ToString(CultureInfo.InvariantCulture);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Invalid input {e.Message}");
                return $"Invalid input {e.Message}";
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Invalid input numbers: {e.Message}");
                return $"Invalid input numbers: {e.Message}";
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error with null value: {e.Message}");
                return $"Error with null value: {e.Message}";
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return $"Error: {e.Message}";
            }

        }

        public static (int n, List<int> numbersOfDepartments, List<int> connections) ReadTreeFromText(string inputText)
        {
            // Розділяємо введений текст на рядки
            var lines = inputText.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(line => line.Trim())
                                 .Where(line => !string.IsNullOrEmpty(line))
                                 .ToList();

            if (lines.Count == 0)
            {
                throw new InvalidOperationException("Input is empty.");
            }

            if (lines.Count != 3)
            {
                throw new InvalidOperationException("Input should contain exactly 3 lines.");
            }

            // Перша лінія — це кількість відділів
            if (!int.TryParse(lines[0], out int n) || n <= 0 || n > 30000)
            {
                throw new InvalidOperationException("First line must contain a natural number (1 < n <= 30000).");
            }

            // Друга лінія — це два номери відділів
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

            // Третя лінія — це батьківські відділи для всіх відділів, окрім кореневого
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

        public static void WriteResult(int result, string outputFilePath)
        {
            File.WriteAllText(outputFilePath, result.ToString(CultureInfo.InvariantCulture));
        }

    }
}
