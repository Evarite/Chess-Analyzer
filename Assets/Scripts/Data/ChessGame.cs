using System;
using System.Collections.Generic;
using Analyzer.APIConnect.ChessCom.DTO;
using Analyzer.APIConnect.Lichess.DTO;

namespace Analyzer.Data
{
    public class ChessGame
    {
        private ChessGame(string url, List<string> uci, string fen, string timeVariant,
            string variant, bool rated, int initialTime, int timeIncrement,
            DateTime endTime, ChessPlayer white, ChessPlayer black, string source)
        {
            URL = url;
            Uci = uci;
            Fen = fen;
            TimeVariant = timeVariant;
            Variant = variant;
            Rated = rated;
            InitialTime = initialTime;
            TimeIncrement = timeIncrement;
            EndTime = endTime;
            White = white;
            Black = black;
            Source = source;
        }

        public string URL { get; }
        public List<string> Uci { get; }
        public string Fen { get; }
        public string TimeVariant { get; }
        public string Variant { get; }
        public bool Rated { get; }
        public int InitialTime { get; }
        public int TimeIncrement { get; }
        public DateTime EndTime { get; }
        public ChessPlayer White { get; }
        public ChessPlayer Black { get; }
        public string Source { get; }

        public static ChessGame FromChessCom(ChessComGame game)
        {
            string[] timeControl = game.TimeControl.Split("+");
            
            int initialTime = int.Parse(timeControl[0]);
            int timeIncrement = 0;

            if (timeControl.Length > 1)
                timeIncrement = int.Parse(timeControl[1]);

            return new(game.URL, game.Uci, game.Fen, game.TimeClass, 
                game.Rules, game.Rated, initialTime, timeIncrement,
                DateTimeOffset.FromUnixTimeSeconds(game.EndTime).LocalDateTime,
                ChessPlayer.FromChessCom(game.White), 
                ChessPlayer.FromChessCom(game.Black), "Chess.com");
        }

        public static ChessGame FromLichess(LichessGame game) =>
            new(game.URL, game.Uci, game.Fen, game.Speed, game.Variant,
                game.Rated, game.Clock?.Initial ?? 0, game.Clock?.Increment ?? 0,
                DateTimeOffset.FromUnixTimeMilliseconds(game.LastMoveAt).LocalDateTime,
                ChessPlayer.FromLichess(game.Players.White),
                ChessPlayer.FromLichess(game.Players.Black), "Lichess.com");
    }
}