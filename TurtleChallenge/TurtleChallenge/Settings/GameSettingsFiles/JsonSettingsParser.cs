using Newtonsoft.Json;

namespace TurtleChallenge.Settings.GameSettingsFiles
{
    public class JsonSettingsParser : ISettingsParser
    {
        public GameSettings Parse(string content)
        {
            return JsonConvert.DeserializeObject<GameSettings>(content);
        }
    }
}
