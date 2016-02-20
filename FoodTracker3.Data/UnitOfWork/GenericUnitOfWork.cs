using FoodTracker3.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker3.Data.UnitOfWork
{
    public class GenericUnitOfWork<T>:IUnitOfWork where T:class
    {
        private FoodTracker3DbContext dbContext;
        public CRUDRepository<T> CRUDRepository { get; private set; }

        public GenericUnitOfWork()
        {
            this.dbContext = new FoodTracker3DbContext();
            this.InitializeRepositories();
        }

        public void InitializeRepositories()
        {
            this.CRUDRepository = new CRUDRepository<T>(this.dbContext);
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
