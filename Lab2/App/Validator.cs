using System.Globalization;

namespace App
{
    public static class Validator
    {
        // Метод для перевірки кількості знаків після коми у числі типу double
        public static void ValidateDecimalPlaces(double number, int maxDecimalPlaces)
        {
            var numberString = number.ToString("F16", CultureInfo.InvariantCulture).TrimEnd('0'); // Конвертуємо число у рядок з максимальною точністю до 16 знаків після коми
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
            ArgumentNullException.ThrowIfNull(arr);

            foreach (var number in arr)
            {
                ValidateDecimalPlaces(number, n);
            }
        }

        // Метод для перевірки чи n у діапазоні [1, 100]
        public static void ValidateN(int n)
        {
            if (n < 1 || n > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "n must be between 1 and 100.");
            }
        }

        // Метод для перевірки чи всі елементи масиву знаходяться у діапазоні [0, 1]
        public static void ValidateArrayRange(double[] arr)
        {
            ArgumentNullException.ThrowIfNull(arr);

            foreach (var number in arr)
            {
                if (number < 0.0 || number > 1.0)
                {
                    throw new ArgumentOutOfRangeException(nameof(arr), "Array elements must be between 0 and 1.");
                }
            }
        }
    }
}
