﻿
namespace TurtleChallenge.BoardPieces
{
    internal class Exit : BoardPiece
    {
        public bool HasTurtleFinished(Turtle turtle)
        {
            return turtle.XPos == XPos && turtle.YPos == YPos;
        }
    }
}