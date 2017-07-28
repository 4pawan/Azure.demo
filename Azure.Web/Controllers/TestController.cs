using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackExchange.Redis;
namespace Azure.Web.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            var connStr = "pwndns.redis.cache.windows.net:6380,password=fZo4urRx55ZfOaC2wQkLwVeuQiSgb5vIbkT+aDGWfgA=,ssl=True,abortConnect=False";

            //Lazy<ConnectionMultiplexer> lzymgr = new Lazy<ConnectionMultiplexer>
            //    (() =>
            //{
            //    return ConnectionMultiplexer.Connect(connStr);
            //});

            //ConnectionMultiplexer conn = lzymgr.Value;
            //IDatabase db = conn.GetDatabase();

            ////Employee empObj = new Employee { Id = 234,Name = "Abc"};
            //db.StringSet("empname", "pawan");
            //var name = db.StringGet("empname");

            return View();
        }

        // GET: Test/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }

        public class Employee
        {
            public string Name { get; set; }
            public int Id { get; set; }

        }
    }
}
