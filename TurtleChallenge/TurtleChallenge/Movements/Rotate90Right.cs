using TurtleChallenge.BoardPieces;

namespace TurtleChallenge.Movements
{
    public class Rotate90Right : ITurtleMovement
    {
        public void Move(Turtle turtle)
        {
            switch (turtle.Direction)
            {
                case Direction.North:
                    turtle.Direction = Direction.East;
                    break;
                case Direction.East:
                    turtle.Direction = Direction.South;
                    break;
                case Direction.South:
                    turtle.Direction = Direction.West;
                    break;
                case Direction.West:
                    turtle.Direction = Direction.North;
                    break;
            }
        }
    }
}
