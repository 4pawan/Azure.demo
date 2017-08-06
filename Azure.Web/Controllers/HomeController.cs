using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;

namespace Azure.Web.Controllers
{

    public class Emp : TableEntity
    {
        static private readonly CloudStorageAccount _csa;

        public static CloudStorageAccount csa
        {
            get
            {
                //return CloudStorageAccount.DevelopmentStorageAccount;
                return CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=pwn22072017;AccountKey=yoDRGiE0aVgLQAZrJaz4XZY+Gt+rNaaxoaL+0C+eKEFZC8DG+dzJdJLjHHJOCWzev28Y7WhMAZcbRzP7lGr4fg==;EndpointSuffix=core.windows.net");
            }
        }


        public int Age { get; set; }
        public string Address { get; set; }
        public double CTC { get; set; }
        public string Name { get; set; }

        public string DeptId { get { return base.PartitionKey; } }
        public string EmpId { get { return base.RowKey; } }
        public Emp(string partitionKey, string rowKey) : base(partitionKey, rowKey)
        {
            // deptId --> partitionKey
            // empId --> rowKey
        }

        public Emp()
        {

        }

        public static void AddEntity()
        {
            var empObj = new Emp("Azure", "10002");
            empObj.Address = "abc@fdfsf.com";
            empObj.Age = 20;
            empObj.Name = "Test123";
            empObj.CTC = 120000;

            //CloudStorageAccount csa = CloudStorageAccount.DevelopmentStorageAccount ;
            var tableClient = csa.CreateCloudTableClient();
            var mycompnytble = tableClient.GetTableReference("mycompany");
            TableOperation op = TableOperation.Insert(empObj);
            var result = mycompnytble.Execute(op);
        }

        public static void ReadEntity()
        {
            //CloudStorageAccount csa = CloudStorageAccount.DevelopmentStorageAccount;
            var tableClient = csa.CreateCloudTableClient();
            var mycompnytble = tableClient.GetTableReference("mycompany");
            TableOperation op = TableOperation.Retrieve<Emp>("Azure", "10001");
            var result = mycompnytble.Execute(op);


            TableQuery<Emp> qry = new TableQuery<Emp>();
            var qryResult = qry.All(e => !string.IsNullOrEmpty(e.RowKey) && Convert.ToInt32(e.RowKey) == 10001);
            //mycompnytble.ExecuteQuery<Emp>(qry);

            //var table = tableClient.GetTableReference("table name");
            //var entities = mycompnytble.ExecuteQuery(qry).ToList().All();
        }

    }



    public class HomeController : Controller
    {
        private readonly CloudStorageAccount _csa;

        public CloudStorageAccount csa
        {
            get
            {
                return CloudStorageAccount.DevelopmentStorageAccount;
                //return CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=pwn22072017;AccountKey=yoDRGiE0aVgLQAZrJaz4XZY+Gt+rNaaxoaL+0C+eKEFZC8DG+dzJdJLjHHJOCWzev28Y7WhMAZcbRzP7lGr4fg==;EndpointSuffix=core.windows.net");
            }
        }

        public ActionResult Test(string c)
        {

            var blobClient = csa.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(c);
            if (container.CreateIfNotExists())
            {
                ViewBag.containerName = container.Name + "is created";
            }
            else
            {
                ViewBag.containerName = "already exists";
            }


            return View("Index");
        }

        public void CreateBlob(string nmae)
        {
            var blobClient = csa.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(nmae);
            if (container.CreateIfNotExists())
            {
                ViewBag.containerName = container.Name + "is created";
            }
            else
            {
                ViewBag.containerName = "already exists";
            }
        }

        public void CreateContainer(string nmae)
        {
            var blobClient = csa.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(nmae);
            container.CreateIfNotExists();
            if (true)
            {
                var blobpermission = new BlobContainerPermissions();
                blobpermission.PublicAccess = BlobContainerPublicAccessType.Blob;
                blobpermission.SharedAccessPolicies.Add("mypolicy", new SharedAccessBlobPolicy
                {
                    Permissions = SharedAccessBlobPermissions.List | SharedAccessBlobPermissions.Read,
                    SharedAccessStartTime = DateTimeOffset.Now,
                    SharedAccessExpiryTime = DateTimeOffset.Now.AddHours(2)
                });
                container.SetPermissions(blobpermission);
            }

        }
        public void ShowContainer()
        {
            var blobClient = csa.CreateCloudBlobClient();
            var list = blobClient.ListContainers();
            foreach (var item in list)
            {
                Response.Write("====>" + item.Name + "/n");
            }

        }

        public void UploadBlob()
        {
            var blobClient = csa.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("mycontainer");
            var blob = container.GetBlockBlobReference("file1.txt");
            blob.UploadText("Welcome to Block Blob.");
        }



        public ActionResult Index()
        {

            CloudStorageAccount csa = CloudStorageAccount.DevelopmentStorageAccount;
            var blobClient = csa.CreateCloudBlobClient();
            //CreateBlob("pwncontainer121");


            //UploadBlob();

            return View();
        }

        public ActionResult About()
        {
            CreateTable();




            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            CreateContainer("mytestcontainer");

            ViewBag.Message = "Your contact page.";

            return View();
        }


        public void CreateTable()
        {
            //CloudStorageAccount csa = CloudStorageAccount.DevelopmentStorageAccount;
            var tableClient = csa.CreateCloudTableClient();
            var mycompnytble = tableClient.GetTableReference("mycompany");
            if (mycompnytble.CreateIfNotExists())
            {
                ViewBag.Message = "table created";
            }
            else
            {
                ViewBag.Message = "exists";
            }


            //Emp.AddEntity();
            Emp.ReadEntity();
        }
    }
}