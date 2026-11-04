using UnityEngine;

namespace Analyzer.Data
{
    [System.Serializable]
    public class ArchivesResponse
    {
        [SerializeField] private string[] _archives;

        public string[] Archives => _archives;
    }
}