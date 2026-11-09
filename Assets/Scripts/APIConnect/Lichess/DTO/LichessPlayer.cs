using Newtonsoft.Json;

namespace Analyzer.APIConnect.Lichess.DTO
{
    public class LichessPlayer
    {
        [JsonProperty("user")] private LichessUser _user;
        [JsonProperty("rating")] private int _rating;
        
        public LichessUser User => _user;
        public int Rating => _rating;
    }
}