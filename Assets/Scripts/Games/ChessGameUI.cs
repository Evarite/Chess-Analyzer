using System;
using TMPro;
using UnityEngine;

namespace Analyzer.Games
{
    public class ChessGameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _dateTime;
        [SerializeField] private TextMeshProUGUI _whiteRating;
        [SerializeField] private TextMeshProUGUI _blackRating;

        public void Setup(string whitePlayerName, string blackPlayerName, long endTime,
            int whiteRating, int blackRating)
        {
            _name.text = $"{whitePlayerName} - {blackPlayerName}";
            _dateTime.text = DateTimeOffset.FromUnixTimeSeconds(endTime)
                .ToString("dd.MM.yyyy HH:mm");
            _whiteRating.text = whiteRating.ToString();
            _blackRating.text = blackRating.ToString();
        }
    }
}