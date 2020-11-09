using System.Text.Json.Serialization;

namespace wf_ui.Models
{
    public class Article
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

    }
}