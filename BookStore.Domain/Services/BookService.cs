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
        void Create(BookBLModel model);
        IEnumerable<BookBLModel> GetAll();
        BookBLModel GetById(int id);
        void Delete(int id);
        void Update(BookBLModel model);
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

        public void Create(BookBLModel model)
        {
            var book = _mapper.Map<Book>(model);
            _genreRepository.Create(book);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookBLModel> GetAll()
        {
            var books = _genreRepository.GetAll();
            var result = _mapper.Map<IEnumerable<BookBLModel>>(books);

            return result;
        }

        public BookBLModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(BookBLModel model)
        {
            throw new NotImplementedException();
        }
    }
}
