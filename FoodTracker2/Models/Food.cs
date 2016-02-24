using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTracker2.Models
{
    public class Food
    {
        public string FoodName { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
    }
}