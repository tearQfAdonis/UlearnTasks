using System;

namespace Goat
{
    internal static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Введите длину веревки (м.) и длину забора (м.) через пробел. " +
                              "Значения не должны превышать 100.");

            // ReSharper disable once PossibleNullReferenceException
            var inputData = Console.ReadLine().Split();

            var ropeLength = int.Parse(inputData[0]);
            var fenceLength = int.Parse(inputData[1]);

            if (IsInputDataCorrect(ropeLength, fenceLength))
            {
                Console.WriteLine($"Козел съел {Math.Round(CalculateEatenArea(ropeLength, fenceLength), 3)} " +
                                  "кв. м. травы. " +
                                  $"Не съедено {Math.Round(CalculateNotEatenArea(ropeLength, fenceLength), 3)} " +
                                  "кв. м. травы.");
            }
            else
            {
                Console.WriteLine("Неверный ввод: введите натуральные числа не больше 100.");
            }
        }

        private static bool IsInputDataCorrect(int ropeLength, int fenceLength)
        {
            return ropeLength < 100 && ropeLength > 0 && fenceLength < 100 && fenceLength > 0;
        }

        private static double CalculateSquareDiagonal(int squareSide)
        {
            return Math.Sqrt(2 * squareSide * squareSide);
        }

        private static double CalculateCircleArea(int radius)
        {
            return radius * radius * Math.PI;
        }

        private static double CalculateSquareArea(int squareSide)
        {
            return squareSide * squareSide;
        }

        private static double CalculateEatenArea(int ropeLength, int fenceLength)
        {
            var kitchenGardenDiagonal = CalculateSquareDiagonal(fenceLength);

            if (ropeLength <= (double)fenceLength / 2)
            {
                return Math.PI * ropeLength * ropeLength;
            }

            if (ropeLength >= kitchenGardenDiagonal / 2)
            {
                return fenceLength * fenceLength;
            }

            return CalculateCircleArea(ropeLength) - 4 * CalculateSegmentAreaOfCircle(ropeLength, fenceLength);
        }

        private static double CalculateNotEatenArea(int ropeLength, int fenceLength)
        {
            return CalculateSquareArea(fenceLength) - CalculateEatenArea(ropeLength, fenceLength);
        }

        private static double CalculateSegmentAreaOfCircle(int circleRadius, int squareSide)
        {
            var halfSquareSide = (double)squareSide / 2;

            var circleChord = 2 * Math.Sqrt(circleRadius * circleRadius - halfSquareSide * halfSquareSide);
            var areaTriangleSector = circleChord * halfSquareSide / 2;

            var sinusCentralAngle = areaTriangleSector / ((double)circleRadius * circleRadius / 2);
            var centralAngle = Math.Asin(sinusCentralAngle);

            var segmentArea = (double)circleRadius * circleRadius / 2 * (centralAngle - sinusCentralAngle);

            return segmentArea;
        }
    }
}