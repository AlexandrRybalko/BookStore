using BookStore.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace BookStore.DAL.Repositories
{
    public interface IGenreRepository
    {
        void Create(Genre model);
        IEnumerable<Genre> GetAll();
        Genre GetById(int id);
        void Delete(int id);
        void Update(Genre model);
    }

    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public override void Create(Genre model)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Genre> GetAll()
        {
            return _table.Include(x => x.Books).ToList();
        }

        public override Genre GetById(int id)
        {
            return _table.Include(x => x.Books)
                .FirstOrDefault(x => x.Id == id); ;
        }

        public override void Update(Genre model)
        {
            var genre = GetById(model.Id);
            genre = model;

            _ctx.SaveChanges();
        }
    }
}
