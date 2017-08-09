using System.Collections.Generic;
using System.Web.Mvc;
using Azure.Web.Helper;
using Azure.Web.Models;
using Microsoft.WindowsAzure.Storage.Table;

namespace Azure.Web.Controllers
{
    public class TableDemoController : Controller
    {
        private static List<StudentEntity> _studentlist = null;
        private static string _tableName = "student";
        public CloudTable TableReference
        {
            get { return TableHelper.GetTableReference(_tableName); }
        }

        public ActionResult Index()
        {
            var model = TableHelper.AddToTable(TableReference, student);

            return View();
        }

        public ActionResult Add()
        {
            var model = GetDummyList();

            foreach (var student in model)
            {
                TableHelper.AddToTable(TableReference, student);
            }

            return View();
        }



        public static List<StudentEntity> GetDummyList()
        {
            _studentlist = new List<StudentEntity>
            {
               new StudentEntity
               {
                  Name = "Ram",
                  Std = "Class1",
                  RollNo = "54"
               },
                new StudentEntity
                {
                    Name = "Shyam",
                    Std = "Class2",
                    RollNo = "32",
                    Courses = new List<Courses>
                    {
                        new Courses {CourseName = "Algebra",Fees = 2000},
                        new Courses {CourseName = "Geometry",Fees = 4500}
                    }
                }
            };

            return _studentlist;
        }
    }
}