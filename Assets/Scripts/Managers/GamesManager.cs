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
        public Dictionary<string, ChessGame> Games { get; } = new();

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
                Games.TryAdd(game.URL, game);
        }
    }
}