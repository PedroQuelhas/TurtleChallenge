using FluentAssertions;
using TurtleChallenge.BoardPieces;
using TurtleChallenge.Movements;

namespace TurtleChallenge.Unit.Movements
{
    [TestClass]
    public class MoveOneSquareTests
    {
        [TestMethod]
        public void MoveOneSquare_Success()
        {
            var turtle = new Turtle
            {
                Direction = Direction.East,
                XPos = 0,
                YPos = 2
            };

            var mover = new MoveOneSquare();
            mover.Move(turtle);

            var expectedTurtle = new Turtle
            {
                Direction = Direction.East,
                XPos = 1,
                YPos = 2
            };

            turtle.Should().BeEquivalentTo(expectedTurtle);
        }

        [TestMethod]
        public void MoveThreeSquares_Success()
        {
            var turtle = new Turtle
            {
                Direction = Direction.East,
                XPos = 0,
                YPos = 2
            };

            var mover = new MoveOneSquare();
            mover.Move(turtle);
            mover.Move(turtle);
            mover.Move(turtle);

            var expectedTurtle = new Turtle
            {
                Direction = Direction.East,
                XPos = 3,
                YPos = 2
            };

            turtle.Should().BeEquivalentTo(expectedTurtle);
        }
    }
}