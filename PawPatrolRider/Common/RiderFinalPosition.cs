namespace PawPatrolRider.Common
{
    public class RiderFinalPosition
    {
        public int X { get; }
        public int Y { get; }
        public Direction Direction { get; }

        public RiderFinalPosition(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}
