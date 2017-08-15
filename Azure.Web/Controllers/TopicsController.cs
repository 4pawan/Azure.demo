using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Azure.Web.Helper;

namespace Azure.Web.Controllers
{
    public class TopicsController : Controller
    {
        // GET: Topics
        public ActionResult Index()
        {
            var model = TopicsServiceBusHelper.ReadMsgFromTopics();

            return View();
        }

        // GET: Topics/Create
        public ActionResult Create()
        {
            var msg = TopicsServiceBusHelper.RandomString(20);
            TopicsServiceBusHelper.SendMsgToTopics(msg);
            return View();
        }

    }
}
