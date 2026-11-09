using Analyzer.APIConnect.ChessCom.DTO;
using Newtonsoft.Json;

namespace Analyzer.Data
{
    public class GamesResponse
    {
        [JsonProperty("games")] private ChessComGame[] _games;
        
        public ChessComGame[] Games => _games;
    }
}