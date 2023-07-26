using TurtleChallenge.Sequences;
using TurtleChallenge.Settings.GameSettingsFiles;
using TurtleChallenge.Settings.MovesFiles;

namespace TurtleChallenge
{
    internal class TurtleGameRunner
    {
        private readonly GameSettings _settings;
        private readonly MovesSettings _moves;
        private readonly bool _visualMode;

        public TurtleGameRunner(GameSettings settings,MovesSettings moves,bool visualMode)
        {
            _settings = settings;
            _moves = moves;
            _visualMode = visualMode;
        }

        public void Run()
        {
            var sequenceNumber = 0;
            foreach (var sequence in _moves.Sequences)
            {
                var board = new Board(_settings);
                RunSequence(sequenceNumber,board, sequence);
                sequenceNumber++;
            }
        }

        private void RunSequence(int number,Board board, TurtleSequence sequence)
        {
            var manager = _visualMode ? new VisualTurtleSequenceManager(number, sequence) : new TurtleSequenceManager(number,sequence);
            manager.ExecuteMoves(board);
        }
    }
}
