using DGS.BusinessObjects.Common;
using DGS.BusinessObjects.DTOs.Order;
using DGS.BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.Repository
{
    public interface IOrderRepository : IRepository<OrderDTO, OrderCreateUpdateDTO, int>
    {
        Task<OrderDTO> FindByUser(string id);
        Task UpdateStatus(int id, OrderStatus status);
        Task<OrderDTO> CreateAndGet(OrderCreateUpdateDTO request);
        Task<EntityFilter<OrderDTO>> FindOrdersByEmail(string email, OrderFilterDTO request);
        Task<EntityFilter<OrderDTO>> Filter(OrderFilterDTO request);
    }
}
