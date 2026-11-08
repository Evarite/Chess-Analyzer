using System;
using System.Linq;
using Analyzer.Data;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

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
        
        public static async Awaitable<ChessGame[]> GetGames(string username, 
            int maxGames = 50)
        {
            string url = $"{BaseUrl}{username}?max={maxGames}&pgnInJson=true";
            string rawNdjson = await Get(url);

            return ParseNdjson(rawNdjson);
        }
        
        private static ChessGame[] ParseNdjson(string ndjson)
        {
            string[] lines = ndjson.Split(new[] { '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            var games = 
                lines.Select(JsonConvert.DeserializeObject<ChessGame>)
                .Where(game => game != null).ToList();

            return games.ToArray();
        }
        
        private static async Awaitable<string> Get(string url)
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
