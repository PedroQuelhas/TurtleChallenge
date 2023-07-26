
using TurtleChallenge.BoardPieces;
using TurtleChallenge.Movements;
using TurtleChallenge.Utils;

namespace TurtleChallenge.Sequences
{
    internal class TurtleSequenceManager : SequenceManager<ITurtleMovement, Turtle>
    {
        protected readonly int SequenceNum;

        public TurtleSequenceManager(int sequenceNum, Sequence<ITurtleMovement, Turtle> sequence) : base(sequence)
        {
            SequenceNum = sequenceNum;
        }

        public override void ExecuteMoves(Board board)
        {
            var status = TurtleStatus.IN_DANGER;
            while (Sequence.HasNext && status == TurtleStatus.IN_DANGER)
            {
                status = ExecuteMove(board);
            }
            TurtleStatusPrinter.PrintSequenceStatus(SequenceNum, status);
        }

        protected virtual TurtleStatus ExecuteMove(Board board)
        {
            return board.MoveTurtle((piece) => Sequence.ApplyNextMovement(piece));
        }
    }
}
