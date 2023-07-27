using Microsoft.Extensions.Hosting;
using TurtleChallenge.Boards;
using TurtleChallenge.Sequences;
using TurtleChallenge.Settings.GameSettingsFiles;
using TurtleChallenge.Settings.MovesFiles;
using TurtleChallenge.Utils;

namespace TurtleChallenge.GameRunner
{
    public class TurtleGameRunner : BackgroundService
    {
        private readonly GameSettings _settings;
        private readonly MovesSettings _moves;
        private readonly bool _visualMode;


        public TurtleGameRunner(GameSettings settings, MovesSettings moves, bool visualMode)
        {
            _settings = settings;
            _moves = moves;
            _visualMode = visualMode;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            {
                var sequenceNumber = 0;
                var manager = new TurtleSequenceManager();

                foreach (var sequence in _moves.Sequences)
                {
                    if (stoppingToken.IsCancellationRequested)
                        return;

                    var board = _visualMode ? new VisualBoard(_settings) : new Board(_settings);
                    var turtleSequence = new TurtleSequence(sequence);

                    manager.ExecuteMoves(board, turtleSequence);
                    
                    TurtleStatusPrinter.PrintSequenceStatus(sequenceNumber, board.GetTurtleStatus());

                    sequenceNumber++;
                }
            });
        }
    }
}
