using Newtonsoft.Json;

namespace TurtleChallenge.Settings.GameSettingsFiles
{
    internal class JsonSettingsParser : ISettingsParser
    {
        private readonly string _jsonData;

        public JsonSettingsParser(string jsonData)
        {
            _jsonData = jsonData;
        }

        public GameSettings Parse()
        {
            return JsonConvert.DeserializeObject<GameSettings>(_jsonData);
        }
    }
}
