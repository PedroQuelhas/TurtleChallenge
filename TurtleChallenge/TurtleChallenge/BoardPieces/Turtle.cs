namespace TurtleChallenge.BoardPieces
{
    public enum TurtleStatus
    {
        SUCCESS,
        MINE_HIT,
        IN_DANGER,
        INVALID_MOVE
    }

    public class Turtle : BoardPiece
    {
        public  Direction Direction { get; set; }
    }
}
