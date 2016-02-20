using FoodTracker3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker3.Data.Repositories
{
    public class MealRepository : GenericRepository<Meal>
    {
        public MealRepository(FoodTracker3DbContext dbcontext)
            :base(dbcontext)
        {

        }
    }
}
