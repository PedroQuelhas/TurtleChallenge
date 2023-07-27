using TurtleChallenge.Movements;

namespace TurtleChallenge.Sequences
{

    internal abstract class Sequence<T, TU> where T : IMovement<TU> where TU : class
    {
        private readonly IEnumerable<T> _movements;
        private readonly IEnumerator<T> _currentPos;
        public bool HasNext { get; set; }
        public Sequence(IEnumerable<T> movements)
        {
            _movements = movements;
            _currentPos = _movements.GetEnumerator();
            HasNext = true;
        }


        public bool ApplyNextMovement(TU piece)
        {
            HasNext = _currentPos.MoveNext();
            if (HasNext)
            {
                _currentPos.Current.Move(piece);
            }
            return HasNext;
        }
    }
}
