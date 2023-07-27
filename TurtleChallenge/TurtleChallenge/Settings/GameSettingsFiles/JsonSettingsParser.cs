using Newtonsoft.Json;

namespace TurtleChallenge.Settings.GameSettingsFiles
{
    internal class JsonSettingsParser : ISettingsParser
    {
        public GameSettings Parse(string content)
        {
            return JsonConvert.DeserializeObject<GameSettings>(content);
        }
    }
}
