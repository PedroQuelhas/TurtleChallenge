using FakeItEasy;
using FluentAssertions;
using TurtleChallenge.BoardPieces;
using TurtleChallenge.Boards;
using TurtleChallenge.Movements;
using TurtleChallenge.Sequences;

namespace TurtleChallenge.Unit.Sequences
{
    [TestClass]
    public class TurtleSequenceTests
    {

        [TestMethod]
        public void ConvertToTurtleMovement_Success()
        {
            var moves = new List<string> { "M", "R", "M" };
            var sequence = TurtleSequence.ConvertToTurtleMovement(moves).ToList();
            var expectedSequence = new List<ITurtleMovement> { new MoveOneSquare(), new Rotate90Right(), new MoveOneSquare() };

            Assert.AreEqual(expectedSequence.Count, sequence.Count);
            for (int i = 0; i < sequence.Count; i++)
            {
                Assert.AreEqual(sequence[i].GetType(), expectedSequence[i].GetType());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Invalid movement provided!")]
        public void ConvertToTurtleMovement_Fail()
        {
            var moves = new List<string> { "M", "D", "M" };
            TurtleSequence.ConvertToTurtleMovement(moves).ToList();
        }


        [TestMethod]
        public void ApplyNextMovement_Success()
        {
            var moves = new List<string> { "M", "R", "M" };
            var sequence = new TurtleSequence(moves);
            var turtle = new Turtle
            {
                Direction = Direction.North,
                XPos = 0,
                YPos = 2
            };

            Assert.AreEqual(true, sequence.ApplyNextMovement(turtle));
            Assert.AreEqual(0, turtle.XPos);
            Assert.AreEqual(1, turtle.YPos);
            Assert.AreEqual(Direction.North, turtle.Direction);


            Assert.AreEqual(true, sequence.ApplyNextMovement(turtle));
            Assert.AreEqual(0, turtle.XPos);
            Assert.AreEqual(1, turtle.YPos);
            Assert.AreEqual(Direction.East, turtle.Direction);

            Assert.AreEqual(true, sequence.ApplyNextMovement(turtle));
            Assert.AreEqual(1, turtle.XPos);
            Assert.AreEqual(1, turtle.YPos);
            Assert.AreEqual(Direction.East, turtle.Direction);

            Assert.AreEqual(false, sequence.ApplyNextMovement(turtle));
        }
    }
}
