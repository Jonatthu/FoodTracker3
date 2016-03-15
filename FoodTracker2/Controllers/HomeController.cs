using FoodTracker3.Business;
using FoodTracker3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTracker3.Controllers
{
    public class HomeController : Controller
    {
        private readonly MealBusiness MealBusiness;
        public HomeController(MealBusiness MealBusiness)
        {
            this.MealBusiness = MealBusiness;
        }

        // GET: Home
        public ActionResult Index()
        {
            ICollection<Meal> list = MealBusiness.GetMeals();
            return View(list);
        }
    }
}