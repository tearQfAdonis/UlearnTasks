using System;

namespace ConsoleApp1
{
    internal static class Sample2
    {
        private static void Main()
        {
            Console.WriteLine("Введите натуральное трехзначное число:");
            
            // ReSharper disable once AssignNullToNotNullAttribute
            var number = int.Parse(Console.ReadLine());

            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (IsCorrectNumber(number))
            {
                Console.WriteLine($"Чудеса!!! {ReverseNumber(number)}");
            }
            else
            {
                Console.WriteLine("Неверный ввод! Прочти условие еще раз!");
            }
        }

        private static bool IsCorrectNumber(int number)
        {
            var numberLength = number.ToString().Length;

            return number > 0 && numberLength == 3;
        }

        private static string ReverseNumber(int number)
        {
            var reversedNumber = number.ToString().ToCharArray();
            Array.Reverse(reversedNumber);

            return string.Concat(reversedNumber);
        }
    }
}