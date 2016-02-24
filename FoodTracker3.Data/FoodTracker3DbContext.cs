using FoodTracker3.Models;
using FoodTracker3.Models.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker3.Data
{
    public class FoodTracker3DbContext : DbContext
    {
        public FoodTracker3DbContext()
            : base("FoodTracker3DbContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        #region DbSets
        public DbSet<Meal> Food { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Congurations
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));
            #endregion

            #region ModelBuilder
            modelBuilder.Configurations.Add(new MealMap());
            #endregion

        }

    }
}
