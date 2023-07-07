using AutoMapper;
using DGS.BusinessObjects.DTOs.Order;
using DGS.BusinessObjects.DTOs.OrderDetail;
using DGS.BusinessObjects.Entities;
using DGS.DataAccess.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.Repository.Impls
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly IOrderDetailDAO _orderDetailDAO;
        private readonly IMapper _mapper;

        public OrderDetailRepository(IOrderDetailDAO orderDetailDAO, IMapper mapper)
        {
            _orderDetailDAO = orderDetailDAO;
            _mapper = mapper;
        }

        public async Task Add(OrderCreateUpdateDTO entity)
        {
            await _orderDetailDAO.Add(_mapper.Map<OrderDetail>(entity));
        }

        public async Task AddRange(List<OrderDetailCreateUpdateDTO> request)
        {
            await _orderDetailDAO.AddMultiple(_mapper.Map<List<OrderDetail>>(request));
        }

        public async Task<OrderDetailDTO> FindById(int id)
        {
            return _mapper.Map<OrderDetailDTO>(await _orderDetailDAO.FindSingle(e => e.Id == id));
        }

        public async Task<List<OrderDetailDTO>> GetAll()
        {
            return _mapper.Map<List<OrderDetailDTO>>(await _orderDetailDAO.GetList());
        }

        public async Task Remove(int id)
        {
            await _orderDetailDAO.Remove(id);
        }

        public async Task Update(OrderCreateUpdateDTO entity)
        {
            await _orderDetailDAO.Update(_mapper.Map<OrderDetail>(entity), "CreatedAt");
        }
    }
}
