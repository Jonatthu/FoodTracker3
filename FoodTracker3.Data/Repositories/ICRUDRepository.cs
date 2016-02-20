using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker3.Data.Repositories
{
    public interface ICRUDRepository<T>:IRepository<T> where T:class
    {
    }
}
