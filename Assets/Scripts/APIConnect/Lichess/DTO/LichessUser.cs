using Newtonsoft.Json;

namespace Analyzer.APIConnect.Lichess.DTO
{
    public class LichessUser
    {
        [JsonProperty("name")] private string _name;
        [JsonProperty("id")] private string _id;

        public string Name => _name;
        public string ID => _id;
    }
}