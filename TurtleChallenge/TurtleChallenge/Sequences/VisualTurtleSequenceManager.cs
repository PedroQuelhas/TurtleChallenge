using TurtleChallenge.BoardPieces;
using TurtleChallenge.Movements;
using TurtleChallenge.Utils;

namespace TurtleChallenge.Sequences
{
    internal class VisualTurtleSequenceManager : TurtleSequenceManager
    {
        public VisualTurtleSequenceManager(int sequenceNum, Sequence<ITurtleMovement, Turtle> sequence) : base(sequenceNum, sequence)
        {
        }

        protected override TurtleStatus ExecuteMove(Board board)
        {
            var status = base.ExecuteMove(board);
            TurtleBoardPrinter.PrintBoard(board);
            TurtleStatusPrinter.PrintSequenceStatus(SequenceNum, status);
            return status;
        }
    }
}
