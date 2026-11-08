using Newtonsoft.Json;

namespace Analyzer.Data
{
    public class ChessPlayer
    {
        [JsonProperty("username")] private string _username;
        [JsonProperty("rating")] private int _rating;
        [JsonProperty("result")] private string _result;
        
        public string Username => _username;
        public int Rating => _rating;
        public string Result => _result;
    }
}