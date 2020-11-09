using System.Text.Json.Serialization;

namespace wf_ui.Models
{
    public class ServiceTask
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("activityId")]
        public string ActivityId { get; set; }

        [JsonPropertyName("activityName")]
        public string ActivityName { get; set; }


    }
}