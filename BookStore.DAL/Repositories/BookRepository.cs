using BookStore.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace BookStore.DAL.Repositories
{
    public interface IBookRepository
    {
        void Create(Book model);
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        void Delete(int id);
        void Update(Book model);
    }

    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public override void Create(Book model)
        {
            _table.Add(model);
            _ctx.SaveChanges();
        }

        public override IEnumerable<Book> GetAll()
        {
            return _table.Include(x => x.Authors)
                .Include(x => x.Orders)
                .Include(x => x.Genres)
                .ToList();
        }

        public override Book GetById(int id)
        {
            return _table.Include(x => x.Authors)
                .Include(x => x.Genres)
                .Include(x => x.Authors)
                .FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Book model)
        {
            var book = GetById(model.Id);
            book = model;

            _ctx.SaveChanges();
        }
    }
}
