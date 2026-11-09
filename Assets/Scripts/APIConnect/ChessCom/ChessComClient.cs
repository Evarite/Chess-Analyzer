using System;
using System.Linq;
using Analyzer.Data;
using Newtonsoft.Json;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;

namespace Analyzer.APIConnect.ChessCom
{
    public static class ChessComClient
    {
        private const string BaseUrl = "https://api.chess.com/pub/player/";
        private const string UrLDescription = "/games/archives";
        private const string RequestHeaderName = "User-Agent";
        private const string RequestHeaderValue = 
            "Chess Analyzer (https://github.com/Evarite/Chess-Analyzer)";

        public static event Action<ChessGame[]> OnGamesLoaded;
        
        public static async UniTask<string[]> GetArchives(string username)
        {
            string json =
                await Get($"{BaseUrl}{username.ToLowerInvariant()}{UrLDescription}");
            return JsonConvert.DeserializeObject<ArchivesResponse>(json).Archives;
        }

        public static async UniTask<ChessGame[]> GetGames(string archiveUrl)
        {
            string json = await Get(archiveUrl);
            
            var chessComGames =
                JsonConvert.DeserializeObject<GamesResponse>(json).Games;

            var games = chessComGames.Select(ChessGame.FromChessCom)
                .ToArray();
            
            OnGamesLoaded?.Invoke(games);
            
            return games;
        }
        
        private static async UniTask<string> Get(string url)
        {
            using var request = UnityWebRequest.Get(url);
            request.SetRequestHeader(RequestHeaderName, RequestHeaderValue);

            await request.SendWebRequest();

            return request.result != UnityWebRequest.Result.Success 
                ? throw new Exception($"{request.responseCode}: {request.error}") 
                : request.downloadHandler.text;
        }
    }
}