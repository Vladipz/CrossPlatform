namespace App
{
    public static class Validator
    {
        // Метод для перевірки кількості знаків після коми у числі типу double
        public static void ValidateDecimalPlaces(double number, int maxDecimalPlaces)
        {
            var numberString = number.ToString("F16").TrimEnd('0'); // Конвертуємо число у рядок з максимальною точністю до 16 знаків після коми

            if (numberString.Contains('.'))
            {
                var decimalPlaces = numberString.Split('.')[1].Length;
                if (decimalPlaces > maxDecimalPlaces)
                {
                    throw new InvalidOperationException($"Number {number} has more than {maxDecimalPlaces} decimal places.");
                }
            }
        }

        public static void ValidateDecimalNumbers(double[] arr, int n)
        {
            foreach (var number in arr)
            {
                ValidateDecimalPlaces(number, n);
            }
        }
    }
}
