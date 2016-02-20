using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker3.Data.UnitOfWork
{
    interface IUnitOfWork : IDisposable
    {
        void InitializeRepositories();
        void SaveChanges();
    }
}
