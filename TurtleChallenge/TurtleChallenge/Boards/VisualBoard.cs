using Spectre.Console;
using TurtleChallenge.BoardPieces;
using TurtleChallenge.Settings.GameSettingsFiles;

namespace TurtleChallenge.Boards
{
    public class VisualBoard : Board, IBoard
    {
        private int _cellSize = 16;
        private int _padding = 2;
        public VisualBoard(GameSettings boardSettings) : base(boardSettings)
        {
            PrintBoard();
        }

        public override TurtleStatus MoveTurtle(Action<Turtle> turtleMover)
        {
            var status = base.MoveTurtle(turtleMover);
            if (status != TurtleStatus.INVALID_MOVE)
                PrintBoard();
            return status;
        }

        private void PrintBoard()
        {
            var canvas = new Canvas(_cellSize * (Settings.Columns + 1), _cellSize * (Settings.Rows + 1));
            AnsiConsole.Live(canvas).Start(ctx =>
            {
                DrawEmptySquares(canvas);
                DrawStartingPoint(canvas);
                DrawMines(canvas);
                DrawExit(canvas);
                DrawTurtle(canvas);
                Thread.Sleep(500);
            });
        }


        private void DrawTurtle(Canvas canvas)
        {
            var originX = Turtle.XPos * _cellSize + _padding * 2;
            var originY = Turtle.YPos * _cellSize + _padding * 2;
            var height = _cellSize - _padding * 4;

            for (var x = 0; x < _padding; x++)
            {
                //legs
                if (Turtle.Direction == Direction.North || Turtle.Direction == Direction.South)
                {
                    canvas.SetPixel(originX - x, originY + height / 4, Color.SandyBrown);
                    canvas.SetPixel(originX - x, originY + height - height / 4, Color.SandyBrown);
                    canvas.SetPixel(originX + x + height, originY + height / 4, Color.SandyBrown);
                    canvas.SetPixel(originX + x + height, originY + height - height / 4, Color.SandyBrown);
                }

                else
                {
                    canvas.SetPixel(originX + height / 4, originY - x, Color.SandyBrown);
                    canvas.SetPixel(originX + height - height / 4, originY - x, Color.SandyBrown);
                    canvas.SetPixel(originX + height / 4, originY + height + x, Color.SandyBrown);
                    canvas.SetPixel(originX + height - height / 4, originY + height + x, Color.SandyBrown);
                }
                //head
                switch (Turtle.Direction)
                {
                    case Direction.North:
                        canvas.SetPixel(originX + height / 2 - 1, originY - 1 - x, Color.SandyBrown);
                        canvas.SetPixel(originX + height / 2, originY - 1 - x, Color.SandyBrown);
                        canvas.SetPixel(originX + height / 2 + 1, originY - 1 - x, Color.SandyBrown);
                        break;
                    case Direction.South:
                        canvas.SetPixel(originX + height / 2 - 1, originY + height + 1 + x, Color.SandyBrown);
                        canvas.SetPixel(originX + height / 2, originY + height + 1 + x, Color.SandyBrown);
                        canvas.SetPixel(originX + height / 2 + 1, originY + height + 1 + x, Color.SandyBrown);
                        break;
                    case Direction.West:
                        canvas.SetPixel(originX - x - 1, originY + height / 2 - 1, Color.SandyBrown);
                        canvas.SetPixel(originX - x - 1, originY + height / 2, Color.SandyBrown);
                        canvas.SetPixel(originX - x - 1, originY + height / 2 + 1, Color.SandyBrown);
                        break;
                    case Direction.East:
                        canvas.SetPixel(originX + height + x + 1, originY + height / 2 - 1, Color.SandyBrown);
                        canvas.SetPixel(originX + height + x + 1, originY + height / 2, Color.SandyBrown);
                        canvas.SetPixel(originX + height + x + 1, originY + height / 2 + 1, Color.SandyBrown);
                        break;
                }

            }
            for (var x = 0; x < _cellSize - _padding * 4 + 1; x++)
            {
                canvas.SetPixel(originX + x, originY, Color.Green3);
                canvas.SetPixel(originX + height, originY + x, Color.Green3);
                canvas.SetPixel(originX + x, originY + height / 2, Color.Green3);
                canvas.SetPixel(originX + x, originY + height, Color.Green3);
                canvas.SetPixel(originX, originY + x, Color.Green3);
                canvas.SetPixel(originX + x, originY + x, Color.Green3);
                canvas.SetPixel(originX + x, originY + height - x, Color.Green3);
            }
        }

        private void DrawExit(Canvas canvas)
        {
            var originX = Exit.XPos * _cellSize + _padding * 2;
            var originY = Exit.YPos * _cellSize + _padding * 2;
            var height = _cellSize - _padding * 4;

            for (var x = 0; x < _cellSize - _padding * 4; x++)
            {
                canvas.SetPixel(originX + x, originY, Color.Green);
                canvas.SetPixel(originX + x, originY + height / 2, Color.Green);
                canvas.SetPixel(originX + x, originY + height, Color.Green);
                canvas.SetPixel(originX, originY + x, Color.Green);
            }
        }

        private void DrawStartingPoint(Canvas canvas)
        {
            var originX = Settings.StartPoint.X * _cellSize;
            var originY = Settings.StartPoint.Y * _cellSize;
            for (var x = 0; x < _cellSize; x++)
            {
                canvas.SetPixel(originX + x, originY, Color.Green);
                canvas.SetPixel(originX + _cellSize, originY + x, Color.Green);
                canvas.SetPixel(originX + _cellSize - x, originY + _cellSize, Color.Green);
                canvas.SetPixel(originX, originY + _cellSize - x, Color.Green);
            }
        }

        private void DrawMines(Canvas canvas)
        {
            foreach (var mine in Mines)
            {
                DrawMine(canvas, mine.XPos, mine.YPos);
            }
        }

        private void DrawEmptySquares(Canvas canvas)
        {
            for (var x = 0; x < Settings.Columns * _cellSize; x += _cellSize)
                for (var y = 0; y < Settings.Rows * _cellSize; y += _cellSize)
                {
                    DrawSquare(canvas, x, y);
                }
        }

        private void DrawSquare(Canvas canvas, int originX, int originY)
        {
            for (var x = 0; x < _cellSize; x++)
            {
                canvas.SetPixel(originX + x, originY, Color.White);
                canvas.SetPixel(originX + _cellSize, originY + x, Color.White);
                canvas.SetPixel(originX + _cellSize - x, originY + _cellSize, Color.White);
                canvas.SetPixel(originX, originY + _cellSize - x, Color.White);

            }
        }


        private void DrawMine(Canvas canvas, int xPos, int yPos)
        {
            var originX = xPos * _cellSize + _padding;
            var originY = yPos * _cellSize + _padding;

            for (var x = 0; x < _cellSize - 2 * _padding + 1; x++)
            {
                canvas.SetPixel(originX + x, originY + x, Color.Red);
                canvas.SetPixel(originX + x, originY + _cellSize - 2 * _padding - x, Color.Red);
            }
        }
    }
}
