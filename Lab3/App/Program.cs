namespace App
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var (n, numbersOfDepartments, connections) = IOHandler.ReadTree();
                Console.WriteLine($"Count of departments: {n}");
                Console.WriteLine($"Suspected departments: {string.Join(" ", numbersOfDepartments)}");
                Console.WriteLine($"Connections: {string.Join(" ", connections)}");
                var lca = DepartmetnsService.Solve(n, numbersOfDepartments, connections);
                IOHandler.WriteResult(lca);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Invalid input {e.Message}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Invalid input numbers: {e.Message}");
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error with null value: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
