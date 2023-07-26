
namespace TurtleChallenge.BoardPieces
{
    internal class Exit : BoardPiece
    {
        public bool HasTurtleFinished(Turtle turtle)
        {
            return MatchCurrentPos(turtle.XPos, turtle.YPos);
        }
    }
}
