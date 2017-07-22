using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using Microsoft.WindowsAzure.Storage;

namespace Azure.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly CloudStorageAccount _csa;

        public CloudStorageAccount csa
        {
            get
            {
                //return CloudStorageAccount.DevelopmentStorageAccount;
                return  CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=pwn22072017;AccountKey=yoDRGiE0aVgLQAZrJaz4XZY+Gt+rNaaxoaL+0C+eKEFZC8DG+dzJdJLjHHJOCWzev28Y7WhMAZcbRzP7lGr4fg==;EndpointSuffix=core.windows.net");
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

        public void  UploadBlob()
        {
            var blobClient = csa.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("mycontainer");
            var blob= container.GetBlockBlobReference("file1.txt");
            blob.UploadText("Welcome to Block Blob.");
        }



        public ActionResult Index()
        {

            CloudStorageAccount csa = CloudStorageAccount.DevelopmentStorageAccount;
            var blobClient = csa.CreateCloudBlobClient();
            CreateBlob("pwncontainer121");


            UploadBlob();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}