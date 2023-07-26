using TurtleChallenge.BoardPieces;

namespace TurtleChallenge.Settings.GameSettingsFiles
{
    internal class GameSettings
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public (int x, int y) StartPoint { get; set; }
        public (int x, int y) Exit { get; set; }
        public IEnumerable<(int x, int y)> Mines { get; set; }
    }
}
