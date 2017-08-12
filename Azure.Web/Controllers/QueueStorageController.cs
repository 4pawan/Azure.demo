using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Azure.Web.Helper;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Azure.Web.Controllers
{
    public class QueueStorageController : Controller
    {

        private string QueueName = "q11";

        private CloudQueue QueueReference
        {
            get { return QueueStorageHelper.GetQueueReference(QueueName); }
        }



        // GET: QueueStorage
        public ActionResult Index()
        {
            var model = QueueStorageHelper.ReadMsgFromQueue(QueueReference);

            return View();
        }

        // GET: QueueStorage/Create
        public ActionResult Create()
        {
            var msg = QueueStorageHelper.RandomString(13);
            QueueStorageHelper.SendMsgToQueue(QueueReference, msg);
            return View();
        }
    }
}
