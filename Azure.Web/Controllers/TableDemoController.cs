using System.Collections.Generic;
using System.Web.Mvc;
using Azure.Web.Models;

namespace Azure.Web.Controllers
{
    public class TableDemoController : Controller
    {
        private static List<StudentEntity> _studentlist = null;
        public ActionResult Index()
        {
            var model = GetDummyList();

            return View();
        }

        public static List<StudentEntity> GetDummyList()
        {
            return _studentlist = new List<StudentEntity>
            {
               new StudentEntity
               {
                  Name = "Ram",
                  Std ="Class1",
                  RollNo = 54
               }
            };
        }
    }
}