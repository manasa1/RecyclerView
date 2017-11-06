using Newtonsoft.Json;

namespace FormsToolkitSample.Models
{
    [JsonObject]
    public class Todo
    {

        [JsonProperty("userId")]
        public string UserIdentifier { get; set; }

        [JsonProperty("id")]
        public long Identifier { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }
    }
}
