using CoreAngCosmos.Models;
using CoreAngCosmos.Models.Helpers;
using Microsoft.Extensions.Configuration;

namespace CoreAngCosmos.Services
{
    public class ItemService: CosmosDbService<Item>, IItemService
    {
        private static readonly IICosmosConfig cosmosConfig = new CosmosConfig
        {
            ContainerName = "Items",
            PartitionKey = "id"
        };

        public ItemService(IConfiguration config) : base(cosmosConfig, config)
        {

        }
    }
}