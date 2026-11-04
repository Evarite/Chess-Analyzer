using UnityEngine;

namespace Analyzer.Data
{
    [System.Serializable]
    public class ChessPlayer
    {
        [SerializeField] private string _username;
        [SerializeField] private int _rating;
        [SerializeField] private string _result;
        
        public string Username => _username;
        public int Rating => _rating;
        public string Result => _result;
    }
}