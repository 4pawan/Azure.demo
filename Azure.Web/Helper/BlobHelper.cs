using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.PeerToPeer;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Azure.Web.Helper
{
    public static class BlobHelper
    {
        private static string CloudStorageString = "DefaultEndpointsProtocol=https;AccountName=r2storageaccount;AccountKey=5xz8ORCiDDhux6uYjTjeQLm0zdgrSu/GjulQcgAaUduGpHs4iLWM1uf4MLGjf9oQLumGEQr42XZKnds8iXNPHw==;EndpointSuffix=core.windows.net";

        public static CloudStorageAccount CloudStorageAccount
        {
            get
            {
                //return CloudStorageAccount.DevelopmentStorageAccount;
                return CloudStorageAccount.Parse(CloudStorageString);
            }
        }
        public static CloudBlobClient BlobServiceClient
        {
            get
            {
                return CloudStorageAccount.CreateCloudBlobClient();
            }
        }
        public static CloudBlobContainer GetContainerReference(string name)
        {
            var reference = BlobServiceClient.GetContainerReference(name);
            reference.CreateIfNotExists(BlobContainerPublicAccessType.Container);
            return reference;
        }

        public static void UploadFile(CloudBlobContainer reference, HttpPostedFileBase file)
        {
            var blobRef = reference.GetBlockBlobReference(file.FileName);
            if (!blobRef.Exists())
            {
                blobRef.UploadFromStream(file.InputStream);
            }
        }

        public static IEnumerable<IListBlobItem> ListAllBlob(CloudBlobContainer reference)
        {
            return reference.ListBlobs();
        }
    }
}