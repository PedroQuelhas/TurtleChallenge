namespace TurtleChallenge.Settings.MovesFiles
{
    public interface IMovesParser
    {
        MovesSettings Parse(string content);

    }
}
