using TurtleChallenge.BoardPieces;

namespace TurtleChallenge.Movements
{
    internal class MoveOneSquare : ITurtleMovement
    {
        public void Move(Turtle turtle)
        {
            turtle.MoveToNewPos(1, turtle.Direction);
        }
    }
}
