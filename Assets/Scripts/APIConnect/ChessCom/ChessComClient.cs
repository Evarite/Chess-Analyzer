using System;
using Analyzer.Data;
using UnityEngine;
using UnityEngine.Networking;

namespace Analyzer.APIConnect.ChessCom
{
    public class ChessComClient
    {
        private const string BaseUrl = "https://api.chess.com/pub/player/";
        private const string UrLDescription = "/games/archives";

        public static async Awaitable<string[]> GetArchives(string username)
        {
            string json =
                await Get($"{BaseUrl}{username.ToLowerInvariant()}{UrLDescription}");
            return JsonUtility.FromJson<ArchivesResponse>(json).Archives;
        }

        public static async Awaitable<ChessGame[]> GetGames(string archiveUrl)
        {
            string json = await Get(archiveUrl);
            return JsonUtility.FromJson<GamesResponse>(json).Games;
        }
        
        private static async Awaitable<string> Get(string url)
        {
            using var request = UnityWebRequest.Get(url);
            request.SetRequestHeader("User-Agent", 
                "Chess Analyzer (https://github.com/Evarite/Chess-Analyzer)");

            await request.SendWebRequest();

            return request.result != UnityWebRequest.Result.Success 
                ? throw new Exception($"{request.responseCode}: {request.error}") 
                : request.downloadHandler.text;
        }
    }
}