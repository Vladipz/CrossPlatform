namespace App
{
    public static class DepartmetnsService
    {
        public static int Solve(int n, List<int>? numbersOfDepartments, List<int>? connections)
        {
            ArgumentNullException.ThrowIfNull(numbersOfDepartments);

            ArgumentNullException.ThrowIfNull(connections);

            // Побудова дерева
            List<int>[] tree = BuildTree(n, connections);

            // Масив глибини відділів
            int[] depth = new int[n + 1];

            // Масив батьківських відділів
            int[] parent = new int[n + 1];

            // Запускаємо DFS для побудови дерева
            DFS(tree, 1, 0, 1, depth, parent);

            // Знаходимо спільного предка
            int lca = FindLCA(numbersOfDepartments[0], numbersOfDepartments[1], depth, parent);

            return lca; // Повертаємо спільного предка
        }


        private static List<int>[] BuildTree(int n, List<int> parents)
        {
            ArgumentNullException.ThrowIfNull(parents);

            // Створюємо масив списків для дерева?сків для дерева
            List<int>[] tree = new List<int>[n + 1];

            // Ініціалізуємо кожен елемент списку
            for (int i = 1; i <= n; i++)
            {
                tree[i] = [];
            }

            // З'єднуємо кожен відділ з батьківським відділом
            for (int i = 2; i <= n; i++)
            {
                tree[parents[i - 2]].Add(i); // parents[i - 2] - батьківський відділ для відділу i
            }

            return tree; // Повертаємо побудоване дерево
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

        // Метод для знаходження LCA (спільного предка)
        private static int FindLCA(int a, int b, int[] depth, int[] parent)
        {
            // Робимо глибини однаковими
            while (depth[a] > depth[b])
            {
                a = parent[a];
            }

            while (depth[b] > depth[a])
            {
                b = parent[b];
            }

            // Піднімаємося одночасно вгору, поки не знайдемо спільного предка не знайдемо спільного предка
            while (a != b)
            {
                a = parent[a];
                b = parent[b];
            }
            return a; // Повертаємо спільного предка
        }
    }
}
