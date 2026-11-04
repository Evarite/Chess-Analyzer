using System;
using UnityEngine;

namespace Analyzer.Data
{
    [Serializable]
    public class GamesResponse
    {
        [SerializeField] private ChessGame[] _games;
        
        public ChessGame[] Games => _games;
    }
}