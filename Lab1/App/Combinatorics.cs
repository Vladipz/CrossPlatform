namespace App
{
    public static class Combinatorics
    {
        public static ulong CombinationsWithouRepetition(ulong n)
        {
            return (n + 1) * n / 2;
        }
    }
}
