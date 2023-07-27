
using TurtleChallenge.Boards;
using TurtleChallenge.BoardPieces;
using TurtleChallenge.Movements;

namespace TurtleChallenge.Sequences
{
    public class TurtleSequenceManager : SequenceManager<ITurtleMovement, Turtle>
    {
        public override void ExecuteMoves(IBoard board, Sequence<ITurtleMovement, Turtle> sequence)
        {
            var status = TurtleStatus.IN_DANGER;
            while (sequence.HasNext && status == TurtleStatus.IN_DANGER)
            {
                status = board.MoveTurtle((piece) => sequence.ApplyNextMovement(piece));
            }
        }
    }
}
