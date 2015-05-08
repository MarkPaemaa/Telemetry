using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using unirest_net.http;

namespace Telemetry.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult SendDataToTelemetry()
        {
            HttpResponse<MyClass> jsonResponse = Unirest.post("http://httpbin.org/post")
              .header("accept", "application/json")
              .field("parameter", "value")
              .field("foo", "bar")
              .asJson<MyClass>();

            return View();
        }
    
    }
}