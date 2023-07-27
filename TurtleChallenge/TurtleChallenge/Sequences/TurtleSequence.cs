using TurtleChallenge.BoardPieces;
using TurtleChallenge.Movements;

namespace TurtleChallenge.Sequences
{
    public class TurtleSequence : Sequence<ITurtleMovement, Turtle>
    {
        public TurtleSequence(IEnumerable<string> moves) : base(ConvertToTurtleMovement(moves))
        {
        }


        public static IEnumerable<ITurtleMovement> ConvertToTurtleMovement(IEnumerable<string> moves)
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

                    default:
                        throw new InvalidOperationException("Invalid movement provided!");
                }
            }
        }
    }
}
