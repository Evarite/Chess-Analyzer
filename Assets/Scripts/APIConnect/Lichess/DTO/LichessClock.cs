using Newtonsoft.Json;

namespace Analyzer.APIConnect.Lichess.DTO
{
    public class LichessClock
    {
        [JsonProperty("initial")] private int _initial;
        [JsonProperty("increment")] private int _increment;

        public int Initial => _initial;
        public int Increment => _increment;
    }
}