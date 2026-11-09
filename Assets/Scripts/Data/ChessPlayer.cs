using Analyzer.APIConnect.ChessCom.DTO;
using Analyzer.APIConnect.Lichess.DTO;

namespace Analyzer.Data
{
    public class ChessPlayer
    {
        private ChessPlayer(string username, int rating)
        {
            Username = username;
            Rating = rating;
        }
        
        public string Username { get; }
        public int Rating { get; }

        public static ChessPlayer FromChessCom(ChessComPlayer player) =>
            new(player.Username, player.Rating);

        public static ChessPlayer FromLichess(LichessPlayer player) => 
            new(player.User?.Name ?? "AI / Anonymous", player.Rating);
    }
}