using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker3.Data.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        private DbContext dbContext;
        private DbSet<T> dbSet;
        private bool disposed = false;

        public GenericRepository(DbContext dbcontext)
        {
            this.dbContext = dbcontext;
            this.dbSet = dbContext.Set<T>();
            this.dbContext.Configuration.LazyLoadingEnabled = false;
            this.dbContext.Configuration.AutoDetectChangesEnabled = false;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }

        private string[] GetKeyNames()
        {
            var objectSet = ((IObjectContextAdapter)this.dbContext).ObjectContext.CreateObjectSet<T>();
            string[] keyNames = objectSet.EntitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();
            return keyNames;
        }

        private string[] GetProperties()
        {
            var objectSet = ((IObjectContextAdapter)this.dbContext).ObjectContext.CreateObjectSet<T>();
            string[] keyNames = objectSet.EntitySet.ElementType.Properties.Select(k => k.Name).ToArray();
            return keyNames;
        }

        private object[] GetPropertiesValues(T entity)
        {
            var keyNames = GetProperties();
            Type type = typeof(T);

            var keys = new object[keyNames.Length];
            for (int i = 0; i < keyNames.Length; i++)
                keys[i] = type.GetProperty(keyNames[i]).GetValue(entity, null);

            return keys;
        }

        private object[] GetPrimaryKeys(T entity)
        {
            var keyNames = GetKeyNames();
            Type type = typeof(T);

            var keys = new object[keyNames.Length];
            for (int i = 0; i < keyNames.Length; i++)
                keys[i] = type.GetProperty(keyNames[i]).GetValue(entity, null);

            return keys;
        }

        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    this.dbContext.Dispose();
            }
            disposed = true;
        }

        public virtual IQueryable<T> GetQuery(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params string[] includeProperties)
        {
            IQueryable<T> query = this.dbSet.AsNoTracking();
            if (filter != null)
                query = query.Where(filter).AsNoTracking();
            foreach (var includeProperty in includeProperties)
                query = query.Include(includeProperty).AsNoTracking();
            if (orderBy != null)
                return orderBy(query).AsNoTracking();
            return query.AsNoTracking();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>,IOrderedQueryable<T>> orderby = null,
            params string[] includeProperties)
        {
            return GetQuery(filter, orderby, includeProperties).AsNoTracking();
        }

        public virtual T GetById(object id)
        {
            return this.dbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            this.dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            var entry = this.dbContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                var key = GetPrimaryKeys(entity)[0];
                var currentEntry = GetById(key);
                if (currentEntry != null)
                {
                    var attachedEntry = this.dbContext.Entry(currentEntry);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    this.dbSet.Attach(entity);
                    this.dbContext.Entry(entity).State = EntityState.Modified;
                }
            }
            else if (entry.State == EntityState.Unchanged)
                this.dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void UpdateAll(T entity)
        {
            this.dbSet.Attach(entity);
            this.dbContext.Entry(entity).State = EntityState.Modified;
            //if (entity.GetType().Name == typeof(Prescription).Name)
            //{
                
            //}
            //var prop = entity.GetType().GetProperties().Where(p => !p.PropertyType.FullName.Contains("System") || p.PropertyType.Name.Contains("ICollection")).ToList();
            
            //foreach(var item in prop)
            //{
            //    var v = item.GetMethod;
            //}

            //var entry = this.dbContext.Entry(entity);
            //var keys = GetPropertiesValues(entity);
            //if (entry.State == EntityState.Detached)
            //{

                

            //    var key = GetPrimaryKeys(entity)[0];
            //    var currentEntry = GetById(key);
            //    if (currentEntry != null)
            //    {
            //        var attachedEntry = this.dbContext.Entry(currentEntry);
            //        attachedEntry.CurrentValues.SetValues(entity);
            //    }
            //    else
            //    {
            //        this.dbSet.Attach(entity);
            //        this.dbContext.Entry(entity).State = EntityState.Modified;
            //    }
            //}
            //else if (entry.State == EntityState.Unchanged)
            //    this.dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            if (this.dbContext.Entry(entity).State == EntityState.Detached)
                this.dbSet.Attach(entity);
            this.dbSet.Remove(entity);
        }

        public virtual void Delete(object id)
        {
            Delete(GetById(id));
        }

        public bool Exists(Expression<Func<T, bool>> filter = null)
        {
            return GetQuery(filter).Any();
        }

        public virtual void Commit()
        {
            this.dbContext.SaveChanges();
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
