using System;
using Analyzer.APIConnect.ChessCom;
using Analyzer.APIConnect.Lichess;
using UnityEngine;

namespace Analyzer.Debugging
{
    public class LichessRequestDebug : MonoBehaviour
    {
        public async void SendRequest()
        {
            try
            {
                Debug.Log("Lichess request send started!");

                var games = await LichessClient.GetGames("Evariite");
                
                Debug.Log("Lichess games received!");
                
                foreach(var game in games)
                    Debug.Log(game);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}