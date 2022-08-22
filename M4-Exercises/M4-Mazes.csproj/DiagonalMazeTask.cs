namespace Mazes
{
    public static class DiagonalMazeTask
    {
        private const int TurnStepsCount = 1;

        public static void MoveOut(Robot robot, int mazeWidth, int mazeHeight)
        {
            if (mazeWidth < mazeHeight)
            {
                LStep(robot, Direction.Right, Direction.Down, mazeWidth, mazeHeight);
            }
            else
            {
                LStep(robot, Direction.Down, Direction.Right, mazeHeight, mazeWidth);
            }
        }

        private static void RobotMove(Robot robot, Direction direction, int stepsCount)
        {
            for (var i = 0; i < stepsCount; i++)
            {
                robot.MoveTo(direction);
            }
        }

        private static void LStep(Robot robot,
                                  Direction directionAlongShortMazeSide,
                                  Direction directionAlongLongMazeSide,
                                  int shortMazeSide,
                                  int longMazeSide)
        {
            var lStepsCount = shortMazeSide - 2;
            var availableStepsCountForRobotMove = longMazeSide / (shortMazeSide - 2);

            for (var i = 0; i < lStepsCount; i++)
            {
                RobotMove(robot, directionAlongLongMazeSide, availableStepsCountForRobotMove);

                if (i < lStepsCount - 1)
                {
                    RobotMove(robot, directionAlongShortMazeSide, TurnStepsCount);
                }
            }
        }
    }
}