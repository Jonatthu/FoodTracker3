using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker3.Models.Mappings
{
    public class MealMap : EntityTypeConfiguration<Meal>
    {
        public MealMap()
        {
            HasKey(a => a.Id);
            Property(a => a.MealName).IsRequired();
            Property(a => a.Description).IsRequired();
            this.ToTable("Meals");
        }
    }
}
