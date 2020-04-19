using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAngCosmos.Helpers;
using CoreAngCosmos.Models;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;

namespace CoreAngCosmos.Services
{
    public class CosmosDbService<T> : ICosmosDbService<T> where T : CosmosItem
    {
        private Container _container;

        protected static CosmosClient _client;
        private readonly IICosmosConfig _cosmosConfig;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cosmosConfig"></param>
        /// <param name="config"></param>
        public CosmosDbService(IICosmosConfig cosmosConfig, IConfiguration config)
        {
            _cosmosConfig = cosmosConfig;

            DatabaseResponse database = null;

            string databaseName = config["CosmosDb:DatabaseName"];

            if (_client == null)
            {
                string account = config["CosmosDb:Account"];
                string key = config["CosmosDb:Key"];

                CosmosClientBuilder clientBuilder = new CosmosClientBuilder(account, key);
                _client = clientBuilder
                    .WithConnectionModeDirect()
                    .Build();

                 database = _client.CreateDatabaseIfNotExistsAsync(databaseName).GetAwaiter().GetResult();
            }

            _container = _client.GetContainer(databaseName, cosmosConfig.ContainerName);
            database?.Database.CreateContainerIfNotExistsAsync(cosmosConfig.ContainerName, $"/{cosmosConfig.PartitionKey}")
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task DeleteItemAsync(string id)
        {
            await this._container.DeleteItemAsync<T>(id, new PartitionKey(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<T>(new QueryDefinition(queryString));
            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<T> GetByIdAsync(string id)
        {
            try
            {
                ItemResponse<T> response = await this._container.ReadItemAsync<T>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual async Task CreateAsync(T item)
        {
            await _container.CreateItemAsync<T>(item, new PartitionKey(item.PartitionKey));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task UpdateAsync(T item)
        {
            await _container.UpsertItemAsync<T>(item, new PartitionKey(item.PartitionKey));
        }
    }
}
