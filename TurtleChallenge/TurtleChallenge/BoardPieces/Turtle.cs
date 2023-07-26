namespace TurtleChallenge.BoardPieces
{
    internal enum TurtleStatus
    {
        SUCCESS,
        MINE_HIT,
        IN_DANGER,
        INVALID_MOVE
    }

    internal class Turtle : BoardPiece
    {
        public  Direction Direction { get; set; }
    }
}
