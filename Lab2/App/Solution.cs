namespace App
{
    public class Solution
    {
        public static double FindProbability(double[] arr, int n)
        {
            ValidateArray(arr, n);

            double prob = 1.0;
            for (int i = 0; i < n; i++)
            {
                prob = (prob * arr[i]) + ((1 - arr[i]) * (1 - prob));
            }
            return prob;
        }

        private static void ValidateArray(double[] arr, int n)
        {
            if (arr.Length != n)
            {
                throw new InvalidOperationException("Number of elements in the second line does not match the first line.");
            }
        }
    }
}
