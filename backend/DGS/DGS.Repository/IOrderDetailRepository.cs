using DGS.BusinessObjects.DTOs.Order;
using DGS.BusinessObjects.DTOs.OrderDetail;
using DGS.BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.Repository
{
    public interface IOrderDetailRepository : IRepository<OrderDetailDTO, OrderCreateUpdateDTO, int>
    {
        Task AddRange(List<OrderDetailCreateUpdateDTO> request);
    }
}
