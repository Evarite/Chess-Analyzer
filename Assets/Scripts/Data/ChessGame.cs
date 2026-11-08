using Newtonsoft.Json;

namespace Analyzer.Data
{
    public class ChessGame
    {
        [JsonProperty("url")] private string _url;
        [JsonProperty("pgn")] private string _pgn;
        [JsonProperty("time_control")] private string _timeControl;
        [JsonProperty("time_class")] private string _timeClass;
        [JsonProperty("rules")] private string _rules;
        [JsonProperty("rated")] private bool _rated;
        [JsonProperty("end_time")] private long _endTime;
        [JsonProperty("white")] private ChessPlayer _white;
        [JsonProperty("black")] private ChessPlayer _black;
        
        public string URL => _url;
        public string Pgn => _pgn;
        public string TimeControl => _timeControl;
        public string TimeClass => _timeClass;
        public string Rules => _rules;
        public bool Rated => _rated;
        public long EndTime => _endTime;
        public ChessPlayer White => _white;
        public ChessPlayer Black => _black;
    }
}