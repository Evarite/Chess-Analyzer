using Analyzer.Managers;
using UnityEngine;
using VContainer;

namespace Analyzer.Debugging
{
    public class LoadedGamesDebug : MonoBehaviour
    {
        [Inject] private GamesManager _gamesManager;

        public void PrintGames()
        {
            foreach (var game in _gamesManager.Games.Values)
            {
                Debug.Log($"Source: {game.Source}\nMoves:{string.Join(", ", game.Uci)}");
            }
        }
    }
}