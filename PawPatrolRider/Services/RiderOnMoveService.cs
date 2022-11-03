using PawPatrolRider.Common;

namespace PawPatrolRider.Services
{
    public class RiderOnMoveService
    {
        public RiderFinalPosition NavigateAndReturnPosition(int xMax, int yMax, string directions)
        {
            var xCurrent = 1;
            var yCurrent = 1;
            var currentDirection = Direction.North;

            var directionCommands = directions.ToCharArray();

            foreach (var directionCommand in directionCommands)
            {
                switch (directionCommand)
                {
                    case 'F':
                        MoveForward(xMax, yMax, ref xCurrent, ref yCurrent, currentDirection);
                        break;
                    case 'L':
                        currentDirection = TurnLeft(currentDirection);
                        break;
                    case 'R':
                        currentDirection = TurnRight(currentDirection);
                        break;
                    default:
                        Console.WriteLine("Invalid Command");
                        break;
                }
            }

            return new RiderFinalPosition(xCurrent, yCurrent, currentDirection);
        }

        private Direction TurnRight(Direction currentDirection)
        {
            switch (currentDirection)
            {
                case Direction.North:
                    currentDirection = Direction.East;
                    break;
                case Direction.South:
                    currentDirection = Direction.West;
                    break;
                case Direction.West:
                    currentDirection = Direction.North;
                    break;
                case Direction.East:
                    currentDirection = Direction.South;
                    break;
            }

            return currentDirection;
        }

        private Direction TurnLeft(Direction currentDirection)
        {
            switch (currentDirection)
            {
                case Direction.North:
                    currentDirection = Direction.West;
                    break;
                case Direction.South:
                    currentDirection = Direction.East;
                    break;
                case Direction.West:
                    currentDirection = Direction.South;
                    break;
                case Direction.East:
                    currentDirection = Direction.North;
                    break;
            }

            return currentDirection;
        }

        private void MoveForward(int xMax, int yMax, ref int xCurrent, ref int yCurrent, Direction currentDirection)
        {
            if (currentDirection == Direction.East && xCurrent < xMax)
            {
                xCurrent++;
            }
            if (currentDirection == Direction.West && xCurrent > 1)
            {
                xCurrent--;
            }
            if (currentDirection == Direction.South && yCurrent > 1)
            {
                yCurrent--;
            }
            if (currentDirection == Direction.North && yCurrent < yMax)
            {
                yCurrent++;
            }
        }
    }
}
