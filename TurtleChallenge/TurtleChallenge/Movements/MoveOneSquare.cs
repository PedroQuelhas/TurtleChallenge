using TurtleChallenge.BoardPieces;

namespace TurtleChallenge.Movements
{
    public class MoveOneSquare : ITurtleMovement
    {
        public void Move(Turtle turtle)
        {
            turtle.MoveToNewPos(1, turtle.Direction);
        }
    }
}
