using UnityEngine;

namespace Analyzer.Data
{
    [System.Serializable]
    public class ChessGame
    {
        [SerializeField] private string _url;
        [SerializeField] private string _pgn;
        [SerializeField] private string _timeControl;
        [SerializeField] private string _timeClass;
        [SerializeField] private string _rules;
        [SerializeField] private bool _rated;
        [SerializeField] private long _endTime;
        [SerializeField] private ChessPlayer _white;
        [SerializeField] private ChessPlayer _black;
        
        public string URL => _url;
        public string Pgn => _pgn;
        public string TimeControl => _timeControl;
        public string TimeClass => _timeClass;
        public string Rules => _rules;
        public bool Rated => _rated;
        public long EndTime => _endTime;
        public ChessPlayer White => _white;
        public ChessPlayer Black => _black;
    }
}