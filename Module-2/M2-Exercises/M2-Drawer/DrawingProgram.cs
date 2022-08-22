using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace RefactorMe
{
    internal static class Drawer
    {
        private static float x;
        private static float y;
        private static Graphics graphics;

        public static void Initialize(Graphics newGraphics)
        {
            graphics = newGraphics;
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.Clear(Color.Black);
        }

        public static void SetStartPoint(int width, int height, int minimalParameter)
        {
            var diagonalLength = Math.Sqrt(2) * (minimalParameter * ImpossibleSquare.FirstCoefficient +
                                                 minimalParameter * ImpossibleSquare.SecondCoefficient) / 2;
            x = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            y = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;
        }

        public static void DrawLineFromCurrentPoint(Pen pen, double length, double angle)
        {
            var startX = x;
            var startY = y;

            MovePenOn(length, angle);

            graphics.DrawLine(pen, x, y, startX, startY);
        }

        public static void MovePenOn(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle));
            y = (float)(y + length * Math.Sin(angle));
        }
    }

    public static class ImpossibleSquare
    {
        public const float FirstCoefficient = 0.375f;
        public const float SecondCoefficient = 0.04f;

        private static readonly Pen Pen = Pens.Fuchsia;

        public static void Draw(int width, int height, double rotationAngle, Graphics graphics)
        {
            var minimalParameter = Math.Min(width, height);

            Drawer.Initialize(graphics);

            Drawer.SetStartPoint(width, height, minimalParameter);

            DrawSide(Pen, minimalParameter, 0, Math.PI / 4, Math.PI,
                     Math.PI / 2, -Math.PI, 3 * Math.PI / 4);
            DrawSide(Pen, minimalParameter, -Math.PI / 2, -Math.PI / 2 + Math.PI / 4,
                     -Math.PI / 2 + Math.PI, -Math.PI / 2 + Math.PI / 2,
                     -Math.PI / 2 - Math.PI, -Math.PI / 2 + 3 * Math.PI / 4);
            DrawSide(Pen, minimalParameter, Math.PI, Math.PI + Math.PI / 4,
                     Math.PI + Math.PI, Math.PI + Math.PI / 2,
                     Math.PI - Math.PI, Math.PI + 3 * Math.PI / 4);
            DrawSide(Pen, minimalParameter, Math.PI / 2, Math.PI / 2 + Math.PI / 4,
                     Math.PI / 2 + Math.PI, Math.PI / 2 + Math.PI / 2,
                     Math.PI / 2 - Math.PI, Math.PI / 2 + 3 * Math.PI / 4);
        }

        private static void DrawSide(Pen pen, int minimalParameter, double angle1, double angle2,
                                     double angle3, double angle4, double angle5, double angle6)
        {
            Drawer.DrawLineFromCurrentPoint(pen, minimalParameter * FirstCoefficient, angle1);
            Drawer.DrawLineFromCurrentPoint(
                pen, minimalParameter * SecondCoefficient * Math.Sqrt(2), angle2);
            Drawer.DrawLineFromCurrentPoint(pen, minimalParameter * FirstCoefficient, angle3);
            Drawer.DrawLineFromCurrentPoint(
                pen, minimalParameter * FirstCoefficient - minimalParameter * SecondCoefficient, angle4);

            Drawer.MovePenOn(minimalParameter * SecondCoefficient, angle5);
            Drawer.MovePenOn(minimalParameter * SecondCoefficient * Math.Sqrt(2), angle6);
        }
    }
}