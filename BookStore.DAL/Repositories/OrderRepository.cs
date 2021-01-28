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
        Order GetById(int id);
        void Delete(int id);
        void Update(Order model);
    }

    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public override IEnumerable<Order> GetAll()
        {
            return _table.Include(x => x.Books).ToList();
        }

        public override void Update(Order model)
        {
            var order = GetById(model.Id);
            order = model;

            _ctx.SaveChanges();
        }
    }
}
