using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Azure.Web.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table.DataServices;
using Microsoft.WindowsAzure.Storage.Table;

namespace Azure.Web.Helper
{
    public static class TableHelper
    {
        private static string CloudStorageString = "DefaultEndpointsProtocol=https;AccountName=r3storageaccount;AccountKey=lon2jmQKYv3e3T6rXFNvgZw5HSuVnmlNpJYXH2uRYV++AjMxjYqa+9e0wMZgii+O72ERI0zabk9F61viHrIaxw==;EndpointSuffix=core.windows.net";

        public static CloudStorageAccount CloudStorageAccount
        {
            get
            {
                //return CloudStorageAccount.DevelopmentStorageAccount;
                return CloudStorageAccount.Parse(CloudStorageString);
            }
        }

        public static CloudTableClient CloudTableServiceClient
        {
            get
            {
                return CloudStorageAccount.CreateCloudTableClient();
            }
        }

        public static CloudTable GetTableReference(string name)
        {
            var reference = CloudTableServiceClient.GetTableReference(name);
            reference.CreateIfNotExists();
            return reference;
        }


        public static TableResult ReadEntitesByKey(CloudTable tableReference, string partitionKey, string rowKey)
        {
            TableResult result = tableReference.Execute(TableOperation.Retrieve<TableEntity>(partitionKey, rowKey));
            return result;
        }
        public static IEnumerable<ITableEntity> ListAll(CloudTable tableReference)
        {

            //TableQuery<ITableEntity> quesry = new TableQuery<ITableEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Smith"));

            var query = new TableQuery<StudentEntity>();
            IEnumerable<ITableEntity> result = tableReference.ExecuteQuery(query);
            return result;
        }


        public static void AddToTable(CloudTable tableReference, ITableEntity entity)
        {
            TableOperation.Insert(entity);
        }

        public static void AddBulkEntitesToTable(CloudTable tableReference, List<ITableEntity> entities)
        {
            TableBatchOperation batchOperation = new TableBatchOperation();
            entities.ForEach(e => batchOperation.Insert(e));
            tableReference.ExecuteBatch(batchOperation);
        }


        public static void DeleteRecordsFromTable(CloudTable tableReference, ITableEntity entity)
        {
            TableOperation.Delete(entity);
        }
    }
}