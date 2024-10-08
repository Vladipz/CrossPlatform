namespace App
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var (n, numbersOfDepartments, connections) = IOHandler.ReadTree();

                var lca = DepartmetnsService.Solve(n, numbersOfDepartments, connections);

                IOHandler.WriteResult(lca);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
