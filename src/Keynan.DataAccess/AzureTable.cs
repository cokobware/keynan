
namespace Keynan.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.CosmosDB.Table;

    public class AzureTable
    {
        public string ConnectionString { get; set; }
        public string TableReference { get; set; }

        public AzureTable() { }

        public AzureTable(string connectionString, string tableReference)
        {
            ConnectionString = connectionString;
            TableReference = tableReference;
        }

        public TableResult Get<T>(string paritionKey, string rowKey) where T : ITableEntity
        {
            var table = GetCloudTable();
            var retrieveOperation = TableOperation.Retrieve<T>(paritionKey, rowKey);
            return table.Execute(retrieveOperation);
        }

        public void Set(ITableEntity entity)
        {
            var table = GetCloudTable();
            var insertOperation = TableOperation.Insert(entity);
            table.Execute(insertOperation);
        }

        private CloudTable GetCloudTable()
        {
            var storageConnectionString = ConnectionString;
            var storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            return tableClient.GetTableReference(TableReference);
        }
    }
}
