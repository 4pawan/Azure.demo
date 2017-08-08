using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            reference.CreateIfNotExists(new TableRequestOptions
            {

            });
            return reference;
        }
    }
}