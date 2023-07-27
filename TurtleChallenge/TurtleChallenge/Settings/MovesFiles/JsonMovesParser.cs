using Newtonsoft.Json;

namespace TurtleChallenge.Settings.MovesFiles
{
    internal class JsonMovesParser : IMovesParser
    {
        public MovesSettings Parse(string content)
        {
            return JsonConvert.DeserializeObject<MovesSettings>(content);
        }
    }
}
