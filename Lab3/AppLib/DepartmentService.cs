namespace App
{
    public static class DepartmetnsService
    {
        public static int Solve(int n, List<int>? numbersOfDepartments, List<int>? connections)
        {
            ArgumentNullException.ThrowIfNull(numbersOfDepartments);

            ArgumentNullException.ThrowIfNull(connections);

            List<int>[] tree = BuildTree(n, connections);

            int[] depth = new int[n + 1];

            int[] parent = new int[n + 1];

            DFS(tree, 1, 0, 1, depth, parent);

            int lca = FindLCA(numbersOfDepartments[0], numbersOfDepartments[1], depth, parent);

            return lca; // Повертаємо спільного предка
        }


        private static List<int>[] BuildTree(int n, List<int> parents)
        {
            ArgumentNullException.ThrowIfNull(parents);

            List<int>[] tree = new List<int>[n + 1];

            for (int i = 1; i <= n; i++)
            {
                tree[i] = [];
            }

            for (int i = 2; i <= n; i++)
            {
                tree[parents[i - 2]].Add(i); 
            }

            return tree; 
        }


        private static void DFS(List<int>[] tree, int current, int parentNode, int currentDepth, int[] depth, int[] parent)
        {
            depth[current] = currentDepth;
            parent[current] = parentNode;

            foreach (var child in tree[current])
            {
                if (child != parentNode)
                {
                    DFS(tree, child, current, currentDepth + 1, depth, parent);
                }
            }
        }

        private static int FindLCA(int a, int b, int[] depth, int[] parent)
        {
            while (depth[a] > depth[b])
            {
                a = parent[a];
            }

            while (depth[b] > depth[a])
            {
                b = parent[b];
            }

            while (a != b)
            {
                a = parent[a];
                b = parent[b];
            }
            return a; 
        }
    }
}
