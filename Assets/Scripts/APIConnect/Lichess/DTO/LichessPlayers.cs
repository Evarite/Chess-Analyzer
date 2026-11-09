using Newtonsoft.Json;

namespace Analyzer.APIConnect.Lichess.DTO
{
    public class LichessPlayers
    {
        [JsonProperty("white")] private LichessPlayer _white;
        [JsonProperty("black")] private LichessPlayer _black;

        public LichessPlayer White => _white;
        public LichessPlayer Black => _black;
    }
}