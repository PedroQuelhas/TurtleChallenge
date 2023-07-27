using FakeItEasy;
using FluentAssertions;
using TurtleChallenge.BoardPieces;
using TurtleChallenge.Boards;
using TurtleChallenge.Movements;
using TurtleChallenge.Sequences;

namespace TurtleChallenge.Unit.Movements
{
    [TestClass]
    public class TurtleSequenceManagerTests
    {
        [TestMethod]
        public void ExecuteMoves_Success()
        {
            var manager = new TurtleSequenceManager();
            var sequence = A.Fake<TurtleSequence>();
            sequence.HasNext = true;

            var board = A.Fake<IBoard>();
            A.CallTo(() => board.MoveTurtle(A<Action<Turtle>>.Ignored)).ReturnsNextFromSequence(TurtleStatus.IN_DANGER, TurtleStatus.IN_DANGER, TurtleStatus.SUCCESS);
            
            manager.ExecuteMoves(board,sequence);
            A.CallTo(() => board.MoveTurtle(A<Action<Turtle>>.Ignored)).MustHaveHappened(3, Times.Exactly);
        }

        [TestMethod]
        public void ExecuteMoves_InvalidMove_Success()
        {
            var manager = new TurtleSequenceManager();
            var sequence = A.Fake<TurtleSequence>();
            sequence.HasNext = true;

            var board = A.Fake<IBoard>();
            A.CallTo(() => board.MoveTurtle(A<Action<Turtle>>.Ignored)).ReturnsNextFromSequence(TurtleStatus.IN_DANGER, TurtleStatus.INVALID_MOVE, TurtleStatus.SUCCESS);

            manager.ExecuteMoves(board, sequence);
            A.CallTo(() => board.MoveTurtle(A<Action<Turtle>>.Ignored)).MustHaveHappened(2, Times.Exactly);
        }
    }
}