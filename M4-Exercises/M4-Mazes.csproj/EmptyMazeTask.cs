namespace Mazes
{
    public static class EmptyMazeTask
    {
        public static void MoveOut(Robot robot, int mazeWidth, int mazeHeight)
        {
            RobotMove(robot, Direction.Right, GetAvailableStepsCountForRobotMove(mazeWidth));
            RobotMove(robot, Direction.Down, GetAvailableStepsCountForRobotMove(mazeHeight));
        }

        private static void RobotMove(Robot robot, Direction direction, int stepsCount)
        {
            for (var i = 0; i < stepsCount; i++)
            {
                robot.MoveTo(direction);
            }
        }

        private static int GetAvailableStepsCountForRobotMove(int mazeSide)
        {
            return mazeSide - 3;
        }
    }
}