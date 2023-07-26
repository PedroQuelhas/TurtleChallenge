using System;
namespace TurtleChallenge.BoardPieces
{
    internal class Mine : BoardPiece
    {
        public bool HasTurtleDied(Turtle turtle)
        {
            return MatchCurrentPos(turtle.XPos, turtle.YPos);
        }
    }
}
