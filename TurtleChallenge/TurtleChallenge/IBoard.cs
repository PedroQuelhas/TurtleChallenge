using TurtleChallenge.BoardPieces;

namespace TurtleChallenge
{
    internal interface IBoard
    {
        TurtleStatus MoveTurtle(Action<Turtle> turtleMover);
    }
}
