namespace CoreAngCosmos.Models
{
    using Newtonsoft.Json;
    using System;

    public class Item: CosmosItem
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "isComplete")]
        public bool Completed { get; set; }

        [JsonProperty(PropertyName = "completedby")]
        public string CompletedBy { get; set; }

        [JsonProperty(PropertyName = "completeddate")]
        public DateTimeOffset? CompletedDate { get; set; }

        [JsonProperty(PropertyName = "createdby")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "createddate")]
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;

        [JsonProperty(PropertyName = "updatedby")]
        public string UpdatedBy { get; set; }

        [JsonProperty(PropertyName = "updateddate")]
        public DateTimeOffset? UpdatedDate { get; set; }

        [JsonIgnore]
        public override string PartitionKey => Id;
    }
}