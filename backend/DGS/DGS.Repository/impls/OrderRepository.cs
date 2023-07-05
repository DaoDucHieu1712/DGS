using AutoMapper;
using DGS.BusinessObjects.DTOs.Order;
using DGS.BusinessObjects.Entities;
using DGS.BusinessObjects.Enums;
using DGS.DataAccess.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.Repository.Impls
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IOrderDAO _orderDAO;
        private readonly IMapper _mapper;

        public OrderRepository()
        {
        }

        public OrderRepository(IOrderDAO orderDAO, IMapper mapper)
        {
            _orderDAO = orderDAO;
            _mapper = mapper;
        }

        public async Task Add(OrderCreateUpdateDTO entity)
        {
            await _orderDAO.Add(_mapper.Map<Order>(entity));
        }

        public async Task<OrderDTO> CreateAndGet(OrderCreateUpdateDTO request)
        {
            var order = _mapper.Map<Order>(request);
            return _mapper.Map<OrderDTO>(await _orderDAO.CreateAndGetEntity(order));
        }

        public async Task<OrderDTO> FindById(int id)
        {
            return _mapper.Map<OrderDTO>(await _orderDAO.FindSingle(e => e.Id == id));
        }

        public async Task<OrderDTO> FindByUser(string id)
        {
            return _mapper.Map<OrderDTO>(await _orderDAO.FindAll(e => e.UserId == id).ToListAsync());
        }

        public async Task<List<OrderDTO>> GetAll()
        {
            return _mapper.Map<List<OrderDTO>>(await _orderDAO.GetList());
        }

        public async Task Remove(int id)
        {
            await _orderDAO.Remove(id);
        }

        public async Task Update(OrderCreateUpdateDTO entity)
        {
            await _orderDAO.Update(_mapper.Map<Order>(entity), "CreatedAt");
        }

        public async Task UpdateStatus(string id, OrderStatus status)
        {
           var order = await _orderDAO.FindSingle(e => e.UserId == id);
           order.Status = status;
           await _orderDAO.Update(order, "CreatedAt");
        }
    }
}
