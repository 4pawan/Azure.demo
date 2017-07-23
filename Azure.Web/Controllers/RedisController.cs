using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI;
using StackExchange.Redis;

namespace Azure.Web.Controllers
{
    public class RedisController : Controller
    {
        // GET: Redis
        public ActionResult Index()
        {

            //var connStr = "pwndns.redis.cache.windows.net:6380,password=fZo4urRx55ZfOaC2wQkLwVeuQiSgb5vIbkT+aDGWfgA=,ssl=True,abortConnect=False";

            //Lazy<ConnectionMultiplexer> lzymgr = new Lazy<ConnectionMultiplexer>
            //(() =>
            //{
            //    return ConnectionMultiplexer.Connect(connStr);
            //});

            //ConnectionMultiplexer conn = lzymgr.Value;
            //IDatabase db = conn.GetDatabase();

            ////Employee empObj = new Employee { Id = 234,Name = "Abc"};
            ////db.StringSet("empname", "pawan");
            //var name = db.StringGet("empname");

             Session.Add("Skey","SValue");   // do get and set cache...it wil autometically will take from redis as defined in web.config
            

            return Index();
        }

       

        // GET: Redis/Create
        public ActionResult Create()
        {

           var content= Session["Session"];

            return Content(content.ToString());
        }
    }
}
