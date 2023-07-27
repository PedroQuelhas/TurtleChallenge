namespace TurtleChallenge.Settings.MovesFiles
{
    internal interface IMovesParser
    {
        MovesSettings Parse(string content);

    }
}
