using System.Collections.Generic;
using System.Linq;
using NChess;
using NChess.Core.Common;
using NChess.Core.Moves;
using NChess.Core.Pieces;

namespace Analyzer.Data
{
    public static class UciConverter
    {
        public static List<string> FromPgn(string pgn)
        {
            var chess = new Chess();
            chess.ImportPgn(pgn);
            return chess.History().Select(h => ToUci(h.Move)).ToList();
        }

        private static string ToUci(Move move)
        {
            string uci = SquareName(move.From) + SquareName(move.To);

            if (move.Promotion.HasValue)
                uci += PromotionLetter(move.Promotion.Value);

            return uci;
        }

        private static char PromotionLetter(PieceType type) =>
            type.ToString().ToLowerInvariant() switch
            {
                "queen"  => 'q',
                "rook"   => 'r',
                "bishop" => 'b',
                "knight" => 'n',
                _        => '\0'
            };

        private static string SquareName(Square s) =>
            $"{(char)('a' + (int)s.File)}{(int)s.Rank + 1}";
    }
}