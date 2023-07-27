namespace TurtleChallenge.Movements
{
    public interface IMovement<T> where T : class
    {
        void Move(T piece);
    }
}
