using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Azure.Web.Implementation.Abstract;
using Microsoft.WindowsAzure.Storage;

namespace Azure.Web.Implementation.Concrete
{
    public class SqlContext : IContext
    {
        private string connstr =
            @"Server=tcp:server1111111.database.windows.net,1433;Initial Catalog=DB1;Persist Security Info=False;User ID=pwnusr;Password=pass123!@#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public CloudStorageAccount CloudStorageAccount
        {
            get
            {

                //return CloudStorageAccount.DevelopmentStorageAccount;
                return CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=pwn22072017;AccountKey=yoDRGiE0aVgLQAZrJaz4XZY+Gt+rNaaxoaL+0C+eKEFZC8DG+dzJdJLjHHJOCWzev28Y7WhMAZcbRzP7lGr4fg==;EndpointSuffix=core.windows.net");

            }
        }

        public void Add()
        {

        }
    }
}