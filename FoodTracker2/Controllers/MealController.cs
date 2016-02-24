using FoodTracker3.Business;
using FoodTracker3.Models;
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
        private MealBusiness MealBusiness;
        public MealController(MealBusiness MealBusiness)
        {
            this.MealBusiness = MealBusiness;
    }
        // GET: Meal
        public ActionResult Index(string id)
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Meal model)
        {
            this.MealBusiness.AddNew(model);
            return View();
        }
    }
}