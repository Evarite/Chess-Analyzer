using Newtonsoft.Json;

namespace Analyzer.Data
{
    public class GamesResponse
    {
        [JsonProperty("games")] private ChessGame[] _games;
        
        public ChessGame[] Games => _games;
    }
}