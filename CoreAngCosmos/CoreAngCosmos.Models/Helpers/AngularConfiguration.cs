using Newtonsoft.Json;

namespace CoreAngCosmos.Models.Helpers
{
    public class AngularConfiguration
    {
        [JsonProperty("apiUrl")]
        public string ApiUrl { get; set; }
    }
}