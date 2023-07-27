
namespace TurtleChallenge.BoardPieces
{
    public class Exit : BoardPiece
    {
        public bool HasTurtleFinished(Turtle turtle)
        {
            return MatchCurrentPos(turtle.XPos, turtle.YPos);
        }
    }
}
