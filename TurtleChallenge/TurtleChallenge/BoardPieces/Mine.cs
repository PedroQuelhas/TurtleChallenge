﻿using System;
namespace TurtleChallenge.BoardPieces
{
    internal class Mine : BoardPiece
    {
        public bool HasTurtleDied(Turtle turtle)
        {
            return turtle.XPos == XPos && turtle.YPos == YPos;
        }
    }
}