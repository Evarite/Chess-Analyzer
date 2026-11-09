using Newtonsoft.Json;

namespace Analyzer.Data
{
    public class ArchivesResponse
    {
        [JsonProperty("archives")] private string[] _archives;

        public string[] Archives => _archives;
    }
}