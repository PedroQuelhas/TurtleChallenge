using TurtleChallenge.BoardPieces;

namespace TurtleChallenge.Boards
{
    public interface IBoard
    {
        TurtleStatus MoveTurtle(Action<Turtle> turtleMover);
    }
}
