using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SignalR.Controllers
{
    public class HomeController : Controller
    {
        private TestEntities db = new TestEntities();


        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult GetData(string hospRTId)
        {

            List<sysHospital> list = new List<sysHospital>();

            try
            {
                list = (from sh in db.sysHospital
                       where sh.HospRTId == hospRTId
                       select sh).ToList();
                foreach (var item in list)
                {
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.Print($"GetData - {ex}");
                list.First().HospImage = ex.Message;
            }

            return new JsonResult
            {
                Data = list,
                MaxJsonLength = int.MaxValue,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
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