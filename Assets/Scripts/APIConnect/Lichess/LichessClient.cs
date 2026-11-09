using System;
using System.Collections.Generic;
using System.Linq;
using Analyzer.APIConnect.Lichess.DTO;
using Analyzer.Data;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;

namespace Analyzer.APIConnect.Lichess
{
    public static class LichessClient
    {
        private const string BaseUrl = "https://lichess.org/api/games/user/";
        private const string AcceptHeaderName = "Accept";
        private const string AcceptHeaderValue = "application/x-ndjson";
        private const string UserAgentHeader = "User-Agent";
        private const string UserAgentValue =
            "Chess Analyzer (https://github.com/Evarite/Chess-Analyzer)";

        private const string Source = "Lichess.org";
        
        public static event Action<ChessGame[]> OnGamesLoaded;
        
        public static async UniTask<ChessGame[]> GetGames(string username, 
            int maxGames = 50)
        {
            string url = $"{BaseUrl}{username}?max={maxGames}&pgnInJson=true&lastFen=true";
            string rawNdjson = await Get(url);

            var lichessGames = ParseNdjson(rawNdjson);
            
            var games = new List<ChessGame>();

            foreach (var g in lichessGames
                         .Where(g => g.Variant == "standard"))
            {
                try
                {
                    games.Add(ChessGame.FromLichess(g));
                }
                catch (Exception e)
                {
                    Debug.LogWarning($"Skipped {g.URL}: {e.Message}");
                }
            }

            var result = games.ToArray();
            OnGamesLoaded?.Invoke(result);
            return result;
        }
        
        private static LichessGame[] ParseNdjson(string ndjson)
        {
            string[] lines = ndjson.Split(new[] { '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            var games = 
                lines.Select(JsonConvert.DeserializeObject<LichessGame>)
                .Where(game => game != null).ToList();
            
            return games.ToArray();
        }
        
        private static async UniTask<string> Get(string url)
        {
            using var request = UnityWebRequest.Get(url);
            
            request.SetRequestHeader(AcceptHeaderName, AcceptHeaderValue);
            request.SetRequestHeader(UserAgentHeader, UserAgentValue);

            await request.SendWebRequest();

            return request.result != UnityWebRequest.Result.Success
                ? throw new Exception($"{request.responseCode}: {request.error}")
                : request.downloadHandler.text;
        }
    }
}
