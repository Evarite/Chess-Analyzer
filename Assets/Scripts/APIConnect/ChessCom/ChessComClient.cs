using System;
using Analyzer.Data;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Analyzer.APIConnect.ChessCom
{
    public static class ChessComClient
    {
        private const string BaseUrl = "https://api.chess.com/pub/player/";
        private const string UrLDescription = "/games/archives";
        private const string RequestHeaderName = "User-Agent";
        private const string RequestHeaderValue = 
            "Chess Analyzer (https://github.com/Evarite/Chess-Analyzer)";

        private const string Source = "Chess.com";

        public static async Awaitable<string[]> GetArchives(string username)
        {
            string json =
                await Get($"{BaseUrl}{username.ToLowerInvariant()}{UrLDescription}");
            return JsonConvert.DeserializeObject<ArchivesResponse>(json).Archives;
        }

        public static async Awaitable<ChessGame[]> GetGames(string archiveUrl)
        {
            string json = await Get(archiveUrl);
            
            var games =
                JsonConvert.DeserializeObject<GamesResponse>(json).Games;
            foreach (var game in games)
                game.Source = Source;
            
            return games;
        }
        
        private static async Awaitable<string> Get(string url)
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