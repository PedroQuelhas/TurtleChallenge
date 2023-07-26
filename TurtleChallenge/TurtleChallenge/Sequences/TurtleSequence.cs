using TurtleChallenge.BoardPieces;
using TurtleChallenge.Movements;

namespace TurtleChallenge.Sequences
{
    internal class TurtleSequence : Sequence<ITurtleMovement, Turtle>
    {
        public TurtleSequence(IEnumerable<ITurtleMovement> movements) : base(movements)
        {
        }
    }
}
