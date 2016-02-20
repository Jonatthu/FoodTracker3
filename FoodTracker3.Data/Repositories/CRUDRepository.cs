using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker3.Data.Repositories
{
    public class CRUDRepository<T>:GenericRepository<T>, ICRUDRepository<T> where T : class
    {
        public CRUDRepository(FoodTracker3DbContext dbcontext)
            :base(dbcontext)
        {

        }
    }
}
