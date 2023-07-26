using TurtleChallenge.BoardPieces;
using TurtleChallenge.Settings.GameSettingsFiles;

namespace TurtleChallenge
{
    internal class Board
    {
        private readonly Turtle _turtle;
        private readonly GameSettings _settings;
        private readonly List<Mine> _mines;
        private readonly Exit _exit;

        public Board(GameSettings boardSettings)
        {
            _settings = boardSettings;
            _turtle = new Turtle
            {
                XPos = _settings.StartPoint.x,
                YPos = _settings.StartPoint.y,
            };
            _mines = _settings.Mines.Select(m=>new Mine { XPos=m.x, YPos=m.y}).ToList();
            _exit = new Exit { XPos = _settings.Exit.x, YPos = _settings.Exit.y };
        }

        public TurtleStatus MoveTurtle(Action<Turtle> turtleMover)
        {
            turtleMover.Invoke(_turtle);
            return EvaluateBoard();
        }

        private TurtleStatus EvaluateBoard()
        {
            if (TurtleIsOutOfBounds())
                return TurtleStatus.INVALID_MOVE;
            
            if (_exit.HasTurtleFinished(_turtle))
                return TurtleStatus.SUCCESS;

            foreach(var m in _mines)
            {
                if (m.HasTurtleDied(_turtle))
                    return TurtleStatus.MINE_HIT;
            }
            return TurtleStatus.IN_DANGER;
        }

        private bool TurtleIsOutOfBounds()
        {
            return _turtle.XPos >= 0 && _turtle.XPos < _settings.Columns && _turtle.YPos >= 0 && _turtle.YPos < _settings.Rows;
        }
    }
}
