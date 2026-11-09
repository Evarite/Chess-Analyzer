using System.Collections.Generic;
using System.Linq;
using NChess;
using Newtonsoft.Json;

namespace Analyzer.APIConnect.ChessCom.DTO
{
    public class ChessComGame
    {
        [JsonProperty("url")] private string _url;
        [JsonProperty("pgn")] private string _pgn;
        [JsonProperty("fen")] private string _fen;
        [JsonProperty("time_control")] private string _timeControl;
        [JsonProperty("time_class")] private string _timeClass;
        [JsonProperty("rules")] private string _rules;
        [JsonProperty("rated")] private bool _rated;
        [JsonProperty("end_time")] private long _endTime;
        [JsonProperty("white")] private ChessComPlayer _white;
        [JsonProperty("black")] private ChessComPlayer _black;
        
        public string URL => _url;
        public string Fen => _fen;
        public string TimeControl => _timeControl;
        public string TimeClass => _timeClass;
        public string Rules => _rules;
        public bool Rated => _rated;
        public long EndTime => _endTime;
        public ChessComPlayer White => _white;
        public ChessComPlayer Black => _black;

        public List<string> Uci
        {
            get
            {
                var chess = new Chess();
                
                chess.ImportPgn(_pgn);
                
                return chess.History().Select(move => move.Move.ToString()).ToList();
            }
        }
    }
}