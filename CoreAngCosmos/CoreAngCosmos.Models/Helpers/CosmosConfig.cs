namespace CoreAngCosmos.Models.Helpers
{
    public class CosmosConfig: IICosmosConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public string ContainerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PartitionKey { get; set; }
    }
}
