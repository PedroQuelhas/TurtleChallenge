
using TurtleChallenge.BoardPieces;
using TurtleChallenge.Boards;
using TurtleChallenge.Movements;

namespace TurtleChallenge.Sequences
{
    public abstract class SequenceManager<T, TU> where T : IMovement<TU> where TU : BoardPiece
    {
        public abstract void ExecuteMoves(IBoard board, Sequence<T, TU> Sequence);
    }
}
