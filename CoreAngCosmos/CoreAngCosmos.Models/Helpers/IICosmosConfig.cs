namespace CoreAngCosmos.Models.Helpers
{
    public interface IICosmosConfig
    {
        string ContainerName { get; set; }

        string PartitionKey { get; set; }
    }
}
