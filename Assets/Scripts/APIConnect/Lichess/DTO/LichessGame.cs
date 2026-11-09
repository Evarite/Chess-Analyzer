using System.Collections.Generic;
using System.Linq;
using NChess;
using Newtonsoft.Json;

namespace Analyzer.APIConnect.Lichess.DTO
{
    public class LichessGame
    {
        [JsonProperty("id")] private string _id;
        [JsonProperty("moves")] private string _moves; 
        [JsonProperty("clock")] private LichessClock _clock;
        [JsonProperty("speed")] private string _speed;
        [JsonProperty("variant")] private string _variant;
        [JsonProperty("rated")] private bool _rated;
        [JsonProperty("lastMoveAt")] private long _lastMoveAt;
        [JsonProperty("players")] private LichessPlayers _players;
        [JsonProperty("winner")] private string _winner; 
        [JsonProperty("status")] private string _status;
        
        public LichessClock Clock => _clock;
        public string Speed => _speed;
        public string Variant => _variant;
        public bool Rated => _rated;
        public long LastMoveAt => _lastMoveAt;
        public LichessPlayers Players => _players;
        public string Winner => _winner;
        public string Status => _status;

        public string URL => $"https://lichess.org/{_id}";
        public List<string> Uci => _moves.Split(" ").ToList();
        public string Fen
        {
            get
            {
                var chess = new Chess();
                
                foreach (string uciMove in Uci
                             .Where(uciMove 
                                 => !string.IsNullOrWhiteSpace(uciMove)))
                    chess.TryMoveUci(uciMove);

                return chess.Fen;
            }
        }
    }
}