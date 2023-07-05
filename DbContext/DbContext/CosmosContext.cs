using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContext
{
    public class CosmosContext : ICosmosContext
    {
        private static Database database;
        private const string endpoint = "https://localhost:8081";
        private const string key = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        public Container userContainer { get; }

        public Container logContainer { get; }

        public CosmosContext()
        {
            CosmosClient _client = CreateConnection();
            //_client.CreateDatabaseIfNotExistsAsync("Work-Project");
            database = _client.CreateDatabaseIfNotExistsAsync("Work-Project").GetAwaiter().GetResult();
            userContainer = database.CreateContainerIfNotExistsAsync("Users", "/username").GetAwaiter().GetResult();
            logContainer = database.CreateContainerIfNotExistsAsync("Logs", "/username").GetAwaiter().GetResult();
        }

        private CosmosClient CreateConnection()
        {
            CosmosClientBuilder cosmosClientBuilder = new CosmosClientBuilder(endpoint, key)
                .WithConnectionModeDirect().WithBulkExecution(true).WithSerializerOptions(new CosmosSerializationOptions()
                {
                    PropertyNamingPolicy = CosmosPropertyNamingPolicy.Default
                });
            return cosmosClientBuilder.Build();
        }
    }
}
