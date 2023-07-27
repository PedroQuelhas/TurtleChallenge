using TurtleChallenge.BoardPieces;

namespace TurtleChallenge.Utils
{
    public static class TurtleStatusPrinter
    {
        public static void PrintSequenceStatus(int sequenceNum, TurtleStatus status)
        {
            Console.WriteLine($"Sequence {sequenceNum+1}: " + GetStatusString(status));
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
