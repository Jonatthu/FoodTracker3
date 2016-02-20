using FoodTracker3.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker3.Data.UnitOfWork
{
    public class MealUnitOfWork : IUnitOfWork
    {
        private FoodTracker3DbContext dbContext;

        public MealRepository MealRepository { get; set; }

        public MealUnitOfWork()
        {
            this.dbContext = new FoodTracker3DbContext();
            InitializeRepositories();
        }

        public void InitializeRepositories()
        {
            this.MealRepository = new MealRepository(dbContext);
        }


        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
