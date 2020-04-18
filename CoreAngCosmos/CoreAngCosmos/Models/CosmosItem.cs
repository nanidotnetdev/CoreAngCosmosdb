using Newtonsoft.Json;

namespace CoreAngCosmos.Models
{
    public class CosmosItem
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}
