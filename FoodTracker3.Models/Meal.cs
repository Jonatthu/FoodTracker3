using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTracker3.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string MealName { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Active { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
    }
}