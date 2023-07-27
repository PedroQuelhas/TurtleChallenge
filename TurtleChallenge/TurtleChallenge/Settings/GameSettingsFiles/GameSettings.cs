using TurtleChallenge.BoardPieces;
using TurtleChallenge.Utils;

namespace TurtleChallenge.Settings.GameSettingsFiles
{
    internal class GameSettings
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Point StartPoint { get; set; }
        public Point Exit { get; set; }
        public IEnumerable<Point> Mines { get; set; }
    }
}
