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
        IEnumerable<BookBLModel> GetMyBooks(string userId);
    }

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository genreRepository, IOrderRepository orderRepository)
        {
            _bookRepository = genreRepository;
            _orderRepository = orderRepository;

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<BLAutoMapperProfile>());
            _mapper = new Mapper(mapperConfig);
        }

        public void Create(BookBLModel model)
        {
            var book = _mapper.Map<Book>(model);
            _bookRepository.Create(book);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookBLModel> GetAll()
        {
            var books = _bookRepository.GetAll();
            var result = _mapper.Map<IEnumerable<BookBLModel>>(books);

            return result;
        }

        public BookBLModel GetById(int id)
        {
            var book = _bookRepository.GetById(id);
            var result = _mapper.Map<BookBLModel>(book);

            return result;
        }

        public IEnumerable<BookBLModel> GetMyBooks(string userId)
        {
            var bookIds = _orderRepository.GetAll()
                .Where(x => x.UserId == userId)
                .SelectMany(x => x.Books.Select(y => y.Id))
                .ToList();
            var myBooks = _bookRepository.GetAll().Where(x => bookIds.Contains(x.Id));

            return _mapper.Map<IEnumerable<BookBLModel>>(myBooks);
        }

        public void Update(BookBLModel model)
        {
            throw new NotImplementedException();
        }
    }
}
