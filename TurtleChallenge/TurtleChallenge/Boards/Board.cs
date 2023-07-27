using TurtleChallenge.BoardPieces;
using TurtleChallenge.Settings.GameSettingsFiles;

namespace TurtleChallenge.Boards
{
    public class Board : IBoard
    {
        private TurtleStatus _currentStatus;
        protected readonly Turtle Turtle;
        protected readonly GameSettings Settings;
        protected readonly List<Mine> Mines;
        protected readonly Exit Exit;

        public Board(GameSettings boardSettings)
        {
            Settings = boardSettings;
            Turtle = new Turtle
            {
                XPos = Settings.StartPoint.X,
                YPos = Settings.StartPoint.Y,
            };
            Mines = Settings.Mines.Select(m => new Mine { XPos = m.X, YPos = m.Y }).ToList();
            Exit = new Exit { XPos = Settings.Exit.X, YPos = Settings.Exit.Y };
        }

        public TurtleStatus GetTurtleStatus()
        {
            return _currentStatus;
        }

        public virtual TurtleStatus MoveTurtle(Action<Turtle> turtleMover)
        {
            turtleMover.Invoke(Turtle);
            _currentStatus = EvaluateBoard();
            return _currentStatus;
        }

        private TurtleStatus EvaluateBoard()
        {
            if (TurtleIsOutOfBounds())
                return TurtleStatus.INVALID_MOVE;

            if (Exit.HasTurtleFinished(Turtle))
                return TurtleStatus.SUCCESS;

            foreach (var m in Mines)
            {
                if (m.HasTurtleDied(Turtle))
                    return TurtleStatus.MINE_HIT;
            }
            return TurtleStatus.IN_DANGER;
        }

        protected bool TurtleIsOutOfBounds()
        {
            return Turtle.XPos < 0 || Turtle.XPos >= Settings.Columns || Turtle.YPos < 0 || Turtle.YPos >= Settings.Rows;
        }
    }
}
