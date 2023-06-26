using AutoMapper;
using DGS.BusinessObjects.DTOs.Product;
using DGS.DataAccess.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.Repository.impls
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductDAO _productDAO;
        private readonly IMapper _mapper;

        public ProductRepository(IProductDAO productDAO, IMapper mapper)
        {
            _productDAO = productDAO;
            _mapper = mapper;
        }

        public Task Add(ProductCreateUpdateDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDTO>> Filter()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(ProductCreateUpdateDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
