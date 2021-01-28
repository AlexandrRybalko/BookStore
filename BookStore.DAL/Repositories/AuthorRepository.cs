using BookStore.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace BookStore.DAL.Repositories
{
    public interface IAuthorRepository
    {
        void Create(Author model);
        IEnumerable<Author> GetAll();
        Author GetById(int id);
        void Delete(int id);
        void Update(Author model);
    }

    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public override IEnumerable<Author> GetAll()
        {
            return _table.Include(x => x.Books).ToList();
        }

        public override void Update(Author model)
        {
            var author = GetById(model.Id);
            author = model;

            _ctx.SaveChanges();
        }
    }
}
