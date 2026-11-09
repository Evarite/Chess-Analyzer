using System;
using System.Collections.Generic;
using System.Linq;
using Analyzer.Data;
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
        [JsonProperty("lastFen")] private string _lastFen;
        
        public LichessClock Clock => _clock;
        public string Speed => _speed;
        public string Variant => _variant;
        public bool Rated => _rated;
        public long LastMoveAt => _lastMoveAt;
        public LichessPlayers Players => _players;
        public string Winner => _winner;
        public string Status => _status;
        public string Fen => _lastFen;

        public string URL => $"https://lichess.org/{_id}";
        public List<string> Uci
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_moves))
                    return new();

                string[] san = _moves.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var sb = new System.Text.StringBuilder();

                for (int i = 0; i < san.Length; i++)
                {
                    if (i % 2 == 0) sb.Append($"{i / 2 + 1}. ");
                    sb.Append(san[i]).Append(' ');
                }

                return UciConverter.FromPgn(sb.ToString());
            }
        }
    }
}