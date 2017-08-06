using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Azure.Web.Controllers
{
    public class BlobDemoController : Controller
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>



        public async Task<ActionResult> Index()
        {
            //var products = db.Products.Include(p => p.ProductCategory).Include(p => p.ProductModel);
            return View();
        }

        public async Task<ActionResult> Add()
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
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    file.SaveAs(path);
                }
            }
            return RedirectToAction("Index");
        }
    }
}