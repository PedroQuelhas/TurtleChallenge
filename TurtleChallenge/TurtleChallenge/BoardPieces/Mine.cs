using System;
namespace TurtleChallenge.BoardPieces
{
    public class Mine : BoardPiece
    {
        public bool HasTurtleDied(Turtle turtle)
        {
            return MatchCurrentPos(turtle.XPos, turtle.YPos);
        }
    }
}
