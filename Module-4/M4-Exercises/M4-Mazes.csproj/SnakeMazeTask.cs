namespace Mazes
{
    public static class SnakeMazeTask
    {
        private const int AvailableStepsCountForRobotVerticalMove = 2;

        public static void MoveOut(Robot robot, int mazeWidth, int mazeHeight)
        {
            var zigzagsCount = GetZigzagCount(mazeHeight);

            for (var i = 0; i < zigzagsCount; i++)
            {
                MoveZigzag(robot, mazeWidth);

                if (i < zigzagsCount - 1)
                {
                    RobotMove(robot, Direction.Down, AvailableStepsCountForRobotVerticalMove);
                }
            }
        }

        private static void RobotMove(Robot robot, Direction direction, int stepsCount)
        {
            for (var i = 0; i < stepsCount; i++)
            {
                robot.MoveTo(direction);
            }
        }

        private static void MoveZigzag(Robot robot, int mazeWidth)
        {
            var availableStepsCountForRobotHorizontalMove = mazeWidth - 3;

            RobotMove(robot, Direction.Right, availableStepsCountForRobotHorizontalMove);
            RobotMove(robot, Direction.Down, AvailableStepsCountForRobotVerticalMove);
            RobotMove(robot, Direction.Left, availableStepsCountForRobotHorizontalMove);
        }

        private static int GetZigzagCount(int mazeSide)
        {
            const int zigzagHeight = 3;
            const int stepsBetweenZigzags = 1;

            return mazeSide / (zigzagHeight + stepsBetweenZigzags);
        }
    }
}