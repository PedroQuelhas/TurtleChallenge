using TurtleChallenge.BoardPieces;
using TurtleChallenge.Movements;

namespace TurtleChallenge.Sequences
{
    internal class TurtleSequence : Sequence<ITurtleMovement, Turtle>
    {
        public TurtleSequence(IEnumerable<string> moves) : base(ConvertToTurtleMovement(moves))
        {
        }


        private static IEnumerable<ITurtleMovement> ConvertToTurtleMovement(IEnumerable<string> moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case "R":
                        yield return new Rotate90Right();
                        break;

                    case "M":
                        yield return new MoveOneSquare();
                        break;
                }
            }
        }
    }
}
