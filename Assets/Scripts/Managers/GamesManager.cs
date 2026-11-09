using System;
using System.Collections.Generic;
using Analyzer.APIConnect.ChessCom;
using Analyzer.APIConnect.Lichess;
using Analyzer.Data;
using JetBrains.Annotations;
using VContainer.Unity;

namespace Analyzer.Managers
{
    [UsedImplicitly]
    public class GamesManager : IInitializable, IDisposable
    {
        private Dictionary<string, ChessGame> _games = new();

        public IReadOnlyDictionary<string, ChessGame> Games => _games;

        public void Initialize()
        {
            ChessComClient.OnGamesLoaded += AddGames;
            LichessClient.OnGamesLoaded += AddGames;
        }

        public void Dispose()
        {
            ChessComClient.OnGamesLoaded -= AddGames;
            LichessClient.OnGamesLoaded -= AddGames;
        }

        private void AddGames(ChessGame[] games)
        {
            foreach (var game in games)
                _games.TryAdd(game.URL, game);
        }
    }
}