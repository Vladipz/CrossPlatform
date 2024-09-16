namespace App
{
    public static class RectanglesService
    {
        public static int GetCountOfRectangles(int w, int h)
        {
            ValidateDimension(w, nameof(w));
            ValidateDimension(h, nameof(h));

            var count_x = Combinatorics.CombinationsWithouRepetition((ulong)w);
            var count_y = Combinatorics.CombinationsWithouRepetition((ulong)h);
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
    }
}
