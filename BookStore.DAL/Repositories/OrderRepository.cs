using BookStore.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookStore.DAL.Repositories
{
    public interface IOrderRepository
    {
        void Create(Order model);
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetByUserId(string userId);
        Order GetById(int id);
        void Delete(int id);
        void Update(Order model);
    }

    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public override void Create(Order model)
        {
            var ids = model.Books.Select(x => x.Id).ToList();
            var books = _ctx.Set<Book>().Where(x => ids.Contains(x.Id)).ToList();
            if(books != null)
            {
                model.Books = books;
            }

            _table.Add(model);
            _ctx.SaveChanges();
        }

        public override IEnumerable<Order> GetAll()
        {
            return _table.Include(x => x.Books).ToList();
        }

        public override Order GetById(int id)
        {
            return _table.Include(x => x.Books)
                .FirstOrDefault(x => x.Id == id); ;
        }

        public IEnumerable<Order> GetByUserId(string userId)
        {
            return _table.Include(x => x.Books)
                .Where(x => x.UserId == userId);
        }

        public override void Update(Order model)
        {
            var order = GetById(model.Id);
            order = model;

            _ctx.SaveChanges();
        }
    }
}
