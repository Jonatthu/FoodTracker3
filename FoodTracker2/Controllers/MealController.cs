using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FoodTracker3.Controllers
{
    public class MealController : Controller
    {
        // GET: Meal
        public ActionResult Index(string id)
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }
    }
}