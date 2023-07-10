using AutoMapper;
using DGS.BusinessObjects.Common;
using DGS.BusinessObjects.DTOs.Order;
using DGS.BusinessObjects.DTOs.OrderDetail;
using DGS.BusinessObjects.DTOs.Product;
using DGS.BusinessObjects.Entities;
using DGS.BusinessObjects.Enums;
using DGS.DataAccess.interfaces;
using DGS.Repository.Helper;
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
            return _mapper.Map<OrderDTO>(await _orderDAO.FindAll(e => e.UserId == id).OrderByDescending(x => x.CreatedAt).ToListAsync());
            
        
        }

        public async Task<List<OrderDTO>> GetAll()
        {
            return _mapper.Map<List<OrderDTO>>(await _orderDAO.GetList());
        }

        public async Task<EntityFilter<OrderDTO>> FindOrdersByEmail(string email , OrderFilterDTO request)
        {
          var queryOrders = await _orderDAO.FindAll(e => e.ApplicationUser).Where(x => x.ApplicationUser.Email == email).OrderByDescending(x => x.CreatedAt).ToListAsync();
            
            if (request.sortType != null)
            {
                switch (request.sortType)
                {
                    case "createdat-asc":
                        queryOrders = queryOrders.OrderBy(x => x.CreatedAt).ToList();
                        break;
                    case "createdat-desc":
                        queryOrders = queryOrders.OrderByDescending(x => x.CreatedAt).ToList();
                        break;
                    default:
                        queryOrders = queryOrders.OrderBy(x => x.CreatedAt).ToList();
                        break;
                }
            }

            if (request.StartDate != null)
            {
                queryOrders = queryOrders.Where(x => x.CreatedAt >= request.StartDate).ToList();
            }

            if (request.EndDate != null)
            {
                queryOrders = queryOrders.Where(x => x.CreatedAt <= request.EndDate).ToList();
            }

            int pageSize = Constants.Contants.PAGE_SIZE;
            List<OrderDTO> _orders = _mapper.Map<List<OrderDTO>>(queryOrders);
            List<OrderDTO> orders = await PagedList<OrderDTO>.CreateAsync(_orders, request.PageIndex ?? 1, pageSize);
            var TotalPages = (int)Math.Ceiling(_orders.Count / (double)pageSize);

            return new EntityFilter<OrderDTO>
            {
                list = orders,
                pageIndex = request.PageIndex ?? 1,
                total = TotalPages,
            };

        }

        public async Task Remove(int id)
        {
            await _orderDAO.Remove(id);
        }

        public async Task Update(OrderCreateUpdateDTO entity)
        {
            await _orderDAO.Update(_mapper.Map<Order>(entity), "CreatedAt");
        }

        public async Task UpdateStatus(int id, OrderStatus status)
        {
           var order = await _orderDAO.FindSingle(e => e.Id == id);
           order.Status = status;
           await _orderDAO.Update(order, "CreatedAt");
        }

        public async Task<EntityFilter<OrderDTO>> Filter(OrderFilterDTO request)
        {
            var queryOrders = await _orderDAO.FindAll().OrderByDescending(x => x.CreatedAt).ToListAsync();
            //Sort
            if (request.sortType != null)
            {
                switch (request.sortType)
                {
                    case "createdat-asc":
                        queryOrders = queryOrders.OrderBy(x => x.CreatedAt).ToList();
                        break;
                    case "createdat-desc":
                        queryOrders = queryOrders.OrderByDescending(x => x.CreatedAt).ToList();
                        break;
                    default:
                        queryOrders = queryOrders.OrderBy(x => x.CreatedAt).ToList();
                        break;
                }
            }

            if(request.StartDate != null)
            {
                queryOrders = queryOrders.Where(x => x.CreatedAt >= request.StartDate).ToList();
            }

            if (request.EndDate != null)
            {
                queryOrders = queryOrders.Where(x => x.CreatedAt <= request.EndDate).ToList();
            }

            int pageSize = Constants.Contants.PAGE_SIZE;
            List<OrderDTO> _orders = _mapper.Map<List<OrderDTO>>(queryOrders);
            List<OrderDTO> orders = await PagedList<OrderDTO>.CreateAsync(_orders, request.PageIndex ?? 1, pageSize);
            var TotalPages = (int)Math.Ceiling(_orders.Count / (double)pageSize);

            return new EntityFilter<OrderDTO>
            {
                list = orders,
                pageIndex = request.PageIndex ?? 1,
                total = TotalPages,
            };

        }

        
    }
}
