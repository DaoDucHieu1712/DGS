using DGS.BusinessObjects.DTOs.Product;
using DGS.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.Repository
{
    public interface IProductRepository : IRepository<ProductDTO, ProductCreateUpdateDTO,int>
    {
        Task<List<ProductDTO>> Filter();
    }
}
