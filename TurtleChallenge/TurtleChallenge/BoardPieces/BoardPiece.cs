namespace TurtleChallenge.BoardPieces
{
    public abstract class BoardPiece
    {
        public int XPos { get; set; }
        public int YPos { get; set; }


        public bool MatchCurrentPos(int x, int y)
        {
            return x == XPos && y == YPos;
        }

        public void MoveToNewPos(int numberOfSquares, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    YPos -= numberOfSquares;
                    break;
                case Direction.South:
                    YPos += numberOfSquares;
                    break;
                case Direction.West:
                    XPos -= numberOfSquares;
                    break;
                case Direction.East:
                    XPos += numberOfSquares;
                    break;
            }
        }
    }
}
