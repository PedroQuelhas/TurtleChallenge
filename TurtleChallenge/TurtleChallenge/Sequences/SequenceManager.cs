
using TurtleChallenge.BoardPieces;
using TurtleChallenge.Movements;

namespace TurtleChallenge.Sequences
{
    internal abstract class SequenceManager<T, TU> where T : IMovement<TU> where TU : BoardPiece
    {
        protected Sequence<T, TU> Sequence;

        public SequenceManager(Sequence<T, TU> sequence)
        {
            Sequence = sequence;
        }

       public abstract void ExecuteMoves(IBoard board);

    }
}
