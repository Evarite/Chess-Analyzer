using System;
using Analyzer.APIConnect.Lichess;
using TMPro;
using UnityEngine;

namespace Analyzer
{
    public class LichessConnect : MonoBehaviour
    {
        [Header("Username Input")]
        [SerializeField] private TMP_InputField _username;
        
        [Header("Message")]
        [SerializeField] private TextMeshProUGUI _messageField;
        [SerializeField] private Color _successColor = Color.green;
        [SerializeField] private Color _failColor = Color.red;
        
        public async void SendRequest()
        {
            try
            {
                var games = await LichessClient.GetGames(_username.text);

                _messageField.color = _successColor;
                _messageField.text = $"Success! {games.Length} games retrieved!";
            }
            catch (Exception e)
            {
                _messageField.color = _failColor;
                _messageField.text = $"Couldn't connect: {e.Message}";
            }
        }
    }
}
