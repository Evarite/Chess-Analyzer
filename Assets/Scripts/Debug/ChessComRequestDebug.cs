using System;
using Analyzer.APIConnect.ChessCom;
using UnityEngine;

namespace Analyzer.Debugging
{
    public class ChessComRequestDebug : MonoBehaviour
    {
        public async void SendRequest()
        {
            try
            {
                Debug.Log("Chess.com request send started!");
                
                string[] archives = await ChessComClient.GetArchives("Evariite");
                
                Debug.Log("Received archives!");
                
                var games = await ChessComClient.GetGames(archives[0]);
            
                Debug.Log("Received games!");
                
                foreach (var game in games)
                    Debug.Log(game.Pgn);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}