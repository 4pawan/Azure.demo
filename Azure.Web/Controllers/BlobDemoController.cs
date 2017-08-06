using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Azure.Web.Helper;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Azure.Web.Controllers
{
    public class BlobDemoController : Controller
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string ContainerName = "tst2";
        private CloudBlobContainer ContainerReference
        {
            get { return BlobHelper.GetContainerReference(ContainerName); }
        }

        public ActionResult Index()
        {
            var model = BlobHelper.ListAllBlob(ContainerReference);
            return View(model);
        }

        public ActionResult Add()
        {
            //var products = db.Products.Include(p => p.ProductCategory).Include(p => p.ProductModel);
            return View();
        }

        [HttpPost]
        public ActionResult Upload()
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    BlobHelper.UploadFile(ContainerReference, file);
                }
            }
            return RedirectToAction("Index");
        }

        
    }
}