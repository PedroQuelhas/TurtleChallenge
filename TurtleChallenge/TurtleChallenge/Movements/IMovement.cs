namespace TurtleChallenge.Movements
{
    internal interface IMovement<T> where T : class
    {
        void Move(T piece);
    }
}
