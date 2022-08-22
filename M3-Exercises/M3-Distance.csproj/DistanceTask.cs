using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        public static double GetDistanceToSegment(double segmentStartX,
                                                  double segmentStartY,
                                                  double segmentEndX,
                                                  double segmentEndY,
                                                  double pointX,
                                                  double pointY)
        {
            var lengthFromPointToEnd = GetSegmentLength(pointX, pointY, segmentEndX, segmentEndY);
            var lengthFromPointToStart = GetSegmentLength(pointX, pointY, segmentStartX, segmentStartY);
            var lengthSegment = GetSegmentLength(segmentStartX, segmentStartY, segmentEndX, segmentEndY);

            var angleOppositeToPointEndSide = GetTriangleAngleOppositeToSide(
                lengthFromPointToEnd, lengthFromPointToStart, lengthSegment);
            var angleOppositeToPointStartSide = GetTriangleAngleOppositeToSide(
                lengthFromPointToStart, lengthFromPointToEnd, lengthSegment);

            if (lengthFromPointToEnd == 0 && lengthFromPointToStart == 0 && lengthSegment == 0)
            {
                return 0;
            }
            if (angleOppositeToPointEndSide <= Math.PI / 2 && angleOppositeToPointStartSide <= Math.PI / 2)
            {
                return GetTriangleHeightToTriangleSide(lengthSegment, lengthFromPointToEnd, lengthFromPointToStart);
            }

            return Math.Min(lengthFromPointToEnd, lengthFromPointToStart);
        }

        private static double GetSegmentLength(double startX, double startY, double endX, double endY)
        {
            var lengthProjectionX = endX - startX;
            var lengthProjectionY = endY - startY;

            return Math.Sqrt(lengthProjectionX * lengthProjectionX + lengthProjectionY * lengthProjectionY);
        }

        private static double GetTriangleHeightToTriangleSide(double heightBaseA, double b, double c)
        {
            return 2 * GetTriangleSquare(heightBaseA, b, c) / heightBaseA;
        }

        private static double GetTriangleAngleOppositeToSide(double sideOppositeToAngle,
                                                             double otherSideOne,
                                                             double otherSideTwo)
        {
            return Math.Acos(
                (otherSideOne * otherSideOne + otherSideTwo * otherSideTwo - sideOppositeToAngle * sideOppositeToAngle)
              / (2 * otherSideOne * otherSideTwo));
        }

        private static double GetTriangleSquare(double a, double b, double c)
        {
            var triangleHalfPerimeter = (a + b + c) / 2;

            return Math.Sqrt(triangleHalfPerimeter *
                             (triangleHalfPerimeter - a) *
                             (triangleHalfPerimeter - b) *
                             (triangleHalfPerimeter - c));
        }
    }
}