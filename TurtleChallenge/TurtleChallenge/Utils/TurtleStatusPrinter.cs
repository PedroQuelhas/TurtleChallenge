using TurtleChallenge.BoardPieces;

namespace TurtleChallenge.Utils
{
    internal static class TurtleStatusPrinter
    {
        public static void PrintSequenceStatus(int sequenceNum, TurtleStatus status)
        {
            Console.WriteLine($"Sequence {sequenceNum}: " + GetStatusString(status));
        }

        private static string GetStatusString(TurtleStatus status)
        {
            return status switch
            {
                TurtleStatus.SUCCESS => "SUCCESS!",
                TurtleStatus.MINE_HIT => "MINE HIT!",
                TurtleStatus.IN_DANGER => "STILL IN DANGER!",
                _ => "OOPS INVALID MOVE!",
            };
        }
    }
}
