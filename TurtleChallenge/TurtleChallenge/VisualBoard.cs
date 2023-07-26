using Spectre.Console;
using System.Collections.Generic;
using TurtleChallenge.BoardPieces;
using TurtleChallenge.Settings.GameSettingsFiles;

namespace TurtleChallenge
{
    internal class VisualBoard : Board, IBoard
    {
        private int _cellSize = 16;
        private int _padding = 2;
        public VisualBoard(GameSettings boardSettings) : base(boardSettings)
        {
        }

        public override TurtleStatus MoveTurtle(Action<Turtle> turtleMover)
        {
            var status = base.MoveTurtle(turtleMover);
            PrintBoard();
            return status;
        }

        private void PrintBoard()
        {
            var canvas = new Canvas(_cellSize * Settings.Columns, _cellSize * Settings.Rows);

            DrawEmptySquares(canvas);
            DrawStartingPoint(canvas);
            DrawMines(canvas);
            DrawExit(canvas);
            DrawTurtle(canvas);
        }

        private void DrawTurtle(Canvas canvas)
        {
            var originX = Turtle.XPos * _cellSize + _padding * 2;
            var originY = Turtle.YPos * _cellSize + _padding * 2;
            var endX = Turtle.XPos * _cellSize + _cellSize - _padding * 2;
            var endY = Turtle.YPos * _cellSize + _cellSize - _padding * 2;
            var midX = originX + (originX - endX) / 2;
            var midY = originY + (originY - endY) / 2;


            //body
            for (var x = originX; x < originX + _cellSize; x++)
            {
                canvas.SetPixel(x, originY, Color.Green3);
                canvas.SetPixel(endX, x, Color.Green3);
                canvas.SetPixel(x, endY, Color.Green3);
                canvas.SetPixel(originX, x, Color.Green3);
                canvas.SetPixel(midX, x, Color.Green3);
                canvas.SetPixel(x, originY + x, Color.Green3);
                canvas.SetPixel(endX - 1 - x, endY - x, Color.Green3);
            }

            for (var x = 0; x < _padding; x++)
            {
                //legs
                if (Turtle.Direction == Direction.North || Turtle.Direction == Direction.South)
                {

                    canvas.SetPixel(originX + _cellSize / 4, originY - x, Color.SandyBrown);
                    canvas.SetPixel(originX + _cellSize / 2, originY - x, Color.SandyBrown);
                    canvas.SetPixel(originX + _cellSize / 4, endY - x, Color.SandyBrown);
                    canvas.SetPixel(originX + _cellSize / 2, endY - x, Color.SandyBrown);
                }

                else
                {
                    canvas.SetPixel(originX - x, originY + _cellSize / 4, Color.SandyBrown);
                    canvas.SetPixel(originX - x, originY + _cellSize / 2, Color.SandyBrown);
                    canvas.SetPixel(endX - x, originY + _cellSize / 4, Color.SandyBrown);
                    canvas.SetPixel(endX - x, originY + _cellSize / 2, Color.SandyBrown);
                }
                //head
                switch (Turtle.Direction)
                {
                    case Direction.North:
                        canvas.SetPixel(originX + _cellSize / 2 - 1, originY - x, Color.SandyBrown);
                        canvas.SetPixel(originX + _cellSize / 2, originY - x, Color.SandyBrown);
                        canvas.SetPixel(originX + _cellSize / 2 + 1, originY - x, Color.SandyBrown);
                        break;
                    case Direction.South:
                        canvas.SetPixel(originX + _cellSize / 2 - 1, originY + _cellSize - x, Color.SandyBrown);
                        canvas.SetPixel(originX + _cellSize / 2, originY + _cellSize - x, Color.SandyBrown);
                        canvas.SetPixel(originX + _cellSize / 2 + 1, originY + _cellSize - x, Color.SandyBrown);
                        break;
                    case Direction.West:
                        break;
                    case Direction.East:
                        break;
                }
            }
        }

        private void DrawExit(Canvas canvas)
        {
            var originX = Exit.XPos * _cellSize + _padding * 2;
            var originY = Exit.YPos * _cellSize + _cellSize + _padding * 2;

            for (var x = originX; x < originX + _cellSize; x++)
            {
                canvas.SetPixel(x, originY, Color.Green);
                canvas.SetPixel(x, originY + _cellSize / 2, Color.Green);
                canvas.SetPixel(x, originY + _cellSize, Color.Green);
                canvas.SetPixel(originX, x, Color.Green);
            }
        }

        private void DrawStartingPoint(Canvas canvas)
        {
            var originX = Settings.StartPoint.x * _cellSize;
            var originY = Settings.StartPoint.x * _cellSize + _cellSize;
            for (var x = originX; x < originX + _cellSize; x++)
            {
                canvas.SetPixel(x, originY, Color.Green);
                canvas.SetPixel(originX + _cellSize, x, Color.Green);
                canvas.SetPixel(x, originY + _cellSize, Color.Green);
                canvas.SetPixel(originX, x, Color.Green);
            }
        }

        private void DrawMines(Canvas canvas)
        {
            foreach (var mine in Mines)
            {
                DrawMine(canvas, mine.XPos * _cellSize, mine.YPos * _cellSize);
            }
        }

        private void DrawEmptySquares(Canvas canvas)
        {
            for (var x = 0; x < Settings.Columns * _cellSize; x += _cellSize)
                for (var y = 0; y < Settings.Columns * _cellSize; y += _cellSize)
                {
                    DrawSquare(canvas, x, y);
                }
        }

        private void DrawSquare(Canvas canvas, int originX, int originY)
        {
            for (var x = originX; x < originX + _cellSize; x++)
            {
                canvas.SetPixel(x, originY, Color.White);
                canvas.SetPixel(originX + _cellSize, x, Color.White);
                canvas.SetPixel(x, originY + _cellSize, Color.White);
                canvas.SetPixel(originX, x, Color.White);
            }
        }


        private void DrawMine(Canvas canvas, int originX, int originY)
        {
            for (var x = originX + _padding; x < originX + _cellSize - _padding; x++)
            {
                canvas.SetPixel(x, originY - x, Color.Red);
                canvas.SetPixel(originX + _cellSize - _padding - 1 - x, originY - _padding - 1 - x, Color.Red);
            }
        }
    }
}
