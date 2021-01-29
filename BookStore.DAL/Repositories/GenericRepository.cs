using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    public abstract class GenericRepository<T> where T : class, IEntity
    {
        protected DbContext _ctx;
        protected DbSet<T> _table;

        public GenericRepository()
        {
            _ctx = new BookStoreContext();
            _table = _ctx.Set<T>();
        }

        public void Create(T model)
        {
            _table.Add(model);

            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _table.Remove(entity);

            _ctx.SaveChanges();
        }

        public abstract IEnumerable<T> GetAll();

        public abstract T GetById(int id);

        public abstract void Update(T model);
    }
}
