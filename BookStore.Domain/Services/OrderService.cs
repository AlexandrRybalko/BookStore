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
    public interface IOrderService
    {
        void Create(OrderBLModel model);
        IEnumerable<OrderBLModel> GetAll();
        OrderBLModel GetById(int id);
        void Delete(int id);
        void Update(OrderBLModel model);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BLAutoMapperProfile>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        public void Create(OrderBLModel model)
        {
            var order = _mapper.Map<Order>(model);
            _orderRepository.Create(order);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderBLModel> GetAll()
        {
            var orders = _orderRepository.GetAll();
            return _mapper.Map<IEnumerable<OrderBLModel>>(orders);
        }

        public OrderBLModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderBLModel model)
        {
            throw new NotImplementedException();
        }
    }
}
