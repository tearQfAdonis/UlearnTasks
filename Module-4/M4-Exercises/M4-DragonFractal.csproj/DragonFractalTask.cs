using System;

namespace Fractals
{
    internal static class DragonFractalTask
    {
        public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
        {
            double startX = 1;
            double startY = 0;

            const double transformationAngleRotation = Math.PI / 4;
            const double pointShiftAlongXAxis = 1;
            var figureCompressionValue = Math.Sqrt(2);

            var randomGenerator = new Random(seed);

            for (var i = 0; i < iterationsCount; i++)
            {
                const int transformationsCount = 2;
                var transformationIndex = randomGenerator.Next(transformationsCount);

                double xNewValue;
                double yNewValue;

                if (transformationIndex == 0)
                {
                    xNewValue = GetXNewValue(startX, startY, transformationAngleRotation, figureCompressionValue);
                    yNewValue = GetYNewValue(startX, startY, transformationAngleRotation, figureCompressionValue);
                }
                else
                {
                    xNewValue =
                        -1 * GetYNewValue(startX, startY, transformationAngleRotation, figureCompressionValue) +
                        pointShiftAlongXAxis;
                    yNewValue = GetXNewValue(startX, startY, transformationAngleRotation, figureCompressionValue);
                }

                startX = xNewValue;
                startY = yNewValue;

                pixels.SetPixel(startX, startY);
            }
        }

        private static double GetXNewValue(double startX, double startY, double transformationAngleRotation,
                                           double figureCompressionValue)
        {
            return (startX * Math.Cos(transformationAngleRotation) -
                    startY * Math.Sin(transformationAngleRotation)) / figureCompressionValue;
        }

        private static double GetYNewValue(double startX, double startY, double transformationAngleRotation,
                                           double figureCompressionValue)
        {
            return (startX * Math.Sin(transformationAngleRotation) +
                    startY * Math.Cos(transformationAngleRotation)) / figureCompressionValue;
        }
    }
}