using System;
using System.Globalization;

namespace Calculate
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Введите через пробел следующие данные: сумму вклада (руб.), " +
                              "годовую процентную ставку (%), срок вклада (мес.):");
            Console.WriteLine($"Ваша конечная сумма составит: {Calculate(Console.ReadLine())}.");
        }

        private static double Calculate(string userInput)
        {
            var inputData = userInput.Split();
            var initialMoneyInRuble = double.Parse(inputData[0], CultureInfo.InvariantCulture);
            var annualInterestRate = double.Parse(inputData[1]);
            var depositTermInMonth = int.Parse(inputData[2]);

            var totalMoneyInRuble = 
                initialMoneyInRuble * Math.Pow(1 + (annualInterestRate / 12 / 100), depositTermInMonth);

            return totalMoneyInRuble;
        }
    }
}
