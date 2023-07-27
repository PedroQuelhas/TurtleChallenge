using FluentAssertions;
using TurtleChallenge.BoardPieces;
using TurtleChallenge.Movements;

namespace TurtleChallenge.Unit.Movements
{
    [TestClass]
    public class Rotate90Tests
    {
        [TestMethod]
        public void RotateNorthToEast_Success()
        {
            var turtle = new Turtle
            {
                Direction = Direction.North,
            };

            var mover = new Rotate90Right();
            mover.Move(turtle);

            var expectedTurtle = new Turtle
            {
                Direction = Direction.East,
            };

            turtle.Should().BeEquivalentTo(expectedTurtle);
        }

        [TestMethod]
        public void RotateEastToSouth_Success()
        {
            var turtle = new Turtle
            {
                Direction = Direction.East,
            };

            var mover = new Rotate90Right();
            mover.Move(turtle);

            var expectedTurtle = new Turtle
            {
                Direction = Direction.South,
            };

            turtle.Should().BeEquivalentTo(expectedTurtle);
        }

        [TestMethod]
        public void RotateSouthToWest_Success()
        {
            var turtle = new Turtle
            {
                Direction = Direction.South,
            };

            var mover = new Rotate90Right();
            mover.Move(turtle);

            var expectedTurtle = new Turtle
            {
                Direction = Direction.West,
            };

            turtle.Should().BeEquivalentTo(expectedTurtle);
        }

        [TestMethod]
        public void RotateWestToNorth_Success()
        {
            var turtle = new Turtle
            {
                Direction = Direction.West,
            };

            var mover = new Rotate90Right();
            mover.Move(turtle);

            var expectedTurtle = new Turtle
            {
                Direction = Direction.North,
            };

            turtle.Should().BeEquivalentTo(expectedTurtle);
        }
    }
}