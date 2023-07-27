using Newtonsoft.Json;

namespace TurtleChallenge.Settings.MovesFiles
{
    public class JsonMovesParser : IMovesParser
    {
        public MovesSettings Parse(string content)
        {
            return JsonConvert.DeserializeObject<MovesSettings>(content);
        }
    }
}
