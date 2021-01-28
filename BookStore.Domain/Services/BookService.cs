using AutoMapper;
using BookStore.DAL.Entities;
using BookStore.DAL.Repositories;
using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Services
{
    public interface IBookService
    {
        void Create(BookModel model);
        IEnumerable<BookModel> GetAll();
        BookModel GetById(int id);
        void Delete(int id);
        void Update(BookModel model);
    }

    public class BookService : IBookService
    {
        private readonly IBookRepository _genreRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository genreRepository)
        {
            _genreRepository = genreRepository;

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<BLAutoMapperProfile>());
            _mapper = new Mapper(mapperConfig);
        }

        public void Create(BookModel model)
        {
            var book = _mapper.Map<Book>(model);
            _genreRepository.Create(book);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public BookModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(BookModel model)
        {
            throw new NotImplementedException();
        }
    }
}
