using System;

namespace Rectangles
{
    public static class RectanglesTask
    {
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            return Math.Max(r1.Left, r2.Left) <= Math.Min(r1.Right, r2.Right) &&
                   Math.Max(r1.Top, r2.Top) <= Math.Min(r1.Bottom, r2.Bottom);
        }

        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            if (!AreIntersected(r1, r2))
            {
                return 0;
            }

            var intersectionLeft = Math.Max(r1.Left, r2.Left);
            var intersectionRight = Math.Min(r1.Right, r2.Right);
            var intersectionTop = Math.Max(r1.Top, r2.Top);
            var intersectionBottom = Math.Min(r1.Bottom, r2.Bottom);

            var intersectionWidth = intersectionRight - intersectionLeft;
            var intersectionHeight = intersectionBottom - intersectionTop;

            return intersectionWidth * intersectionHeight;
        }

        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            if (IsRectangleContainsOtherRectangle(r1, r2))
            {
                return 1;
            }
            if (IsRectangleContainsOtherRectangle(r2, r1))
            {
                return 0;
            }

            return -1;
        }

        private static bool IsRectangleContainsOtherRectangle(Rectangle rectangle, Rectangle otherRectangle)
        {
            return rectangle.Left <= otherRectangle.Left && rectangle.Right >= otherRectangle.Right &&
                   rectangle.Bottom >= otherRectangle.Bottom && rectangle.Top <= otherRectangle.Top;
        }
    }
}