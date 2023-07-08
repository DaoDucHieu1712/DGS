using AutoMapper;
using DGS.BusinessObjects.DTOs.Product;
using DGS.BusinessObjects.Entities;
using DGS.DataAccess.impls;
using DGS.DataAccess.interfaces;
using DGS.Repository.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DGS.Repository.Impls
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

        public async Task Add(ProductCreateUpdateDTO entity)
        {
            await _productDAO.Add(_mapper.Map<Product>(entity));
        }

        public async Task AddMultiple(List<ProductCreateUpdateDTO> products)
        {
            await _productDAO.AddMultiple(_mapper.Map<List<Product>>(products));
        }

        public async Task<ProductFilterAndPagingDTO> Filter(ProductFilterDTO request)
        {
            var queryProduct =  await _productDAO.FindAll(x => x.Category).OrderByDescending(x => x.Id).ToListAsync();

            //Sort
            if (request.sortType != null)
            {
                switch (request.sortType)
                {
                    case "name-asc":
                        queryProduct = queryProduct.OrderBy(x => x.Name).ToList();
                        break;
                    case "name-desc":
                        queryProduct = queryProduct.OrderByDescending(x => x.Name).ToList();
                        break;
                    case "price-asc":
                        queryProduct = queryProduct.OrderBy(x => x.Price).ToList();
                        break;
                    case "price-desc":
                        queryProduct = queryProduct.OrderByDescending(x => x.Price).ToList();
                        break;
                    default:
                        queryProduct = queryProduct.OrderBy(x => x.Name).ToList();
                        break;
                }
            }

            //Filter
            if (request.Name != null)
            {
                queryProduct = queryProduct.Where(x => x.Name.ToLower().Contains(request.Name.ToLower())).ToList();
            }

            if (request.ToPrice != null)
            {
                queryProduct = queryProduct.Where(x => x.Price >= request.ToPrice).ToList();
            }

            if (request.FromPrice != null)
            {
                queryProduct = queryProduct.Where(x => x.Price <= request.FromPrice).ToList();
            }

            if (request.CategoryId != null)
            {
                queryProduct = queryProduct.Where(x => x.CategoryId == request.CategoryId).ToList();
            }

            //Paging
            int pageSize = Constants.Contants.PAGE_SIZE;
            List<ProductDTO> _products = _mapper.Map<List<ProductDTO>>(queryProduct);
            List<ProductDTO> products = await PagedList<ProductDTO>.CreateAsync(_products, request.pageIndex ?? 1, pageSize);
            var TotalPages = (int)Math.Ceiling(_products.Count / (double)pageSize);

            return new ProductFilterAndPagingDTO
            {
                Products = products,
                PageIndex = request.pageIndex ?? 1,
                Total = TotalPages,
            };
        }


        public async Task<ProductDTO> FindById(int id)
        {
            return _mapper.Map<ProductDTO>(await _productDAO.FindSingle(e => e.Id == id));
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            return _mapper.Map<List<ProductDTO>>(await _productDAO.FindAll(x => x.Category).ToListAsync());
        }

        public async Task Remove(int id)
        {
            await _productDAO.Remove(id);
        }

        public async Task<List<ProductDTO>> Search(ProductFilterDTO request)
        {
            var queryProduct = await _productDAO.FindAll(x => x.Category).OrderByDescending(x => x.Id).ToListAsync();

            //Sort
            if (request.sortType != null)
            {
                switch (request.sortType)
                {
                    case "name-asc":
                        queryProduct = queryProduct.OrderBy(x => x.Name).ToList();
                        break;
                    case "name-desc":
                        queryProduct = queryProduct.OrderByDescending(x => x.Name).ToList();
                        break;
                    case "price-asc":
                        queryProduct = queryProduct.OrderBy(x => x.Price).ToList();
                        break;
                    case "price-desc":
                        queryProduct = queryProduct.OrderByDescending(x => x.Price).ToList();
                        break;
                    default:
                        queryProduct = queryProduct.OrderBy(x => x.Name).ToList();
                        break;
                }
            }

            //Filter
            if (request.Name != null)
            {
                queryProduct = queryProduct.Where(x => x.Name.ToLower().Contains(request.Name.ToLower())).ToList();
            }

            if (request.ToPrice != null)
            {
                queryProduct = queryProduct.Where(x => x.Price >= request.ToPrice).ToList();
            }

            if (request.FromPrice != null)
            {
                queryProduct = queryProduct.Where(x => x.Price <= request.FromPrice).ToList();
            }

            if (request.CategoryId != null)
            {
                queryProduct = queryProduct.Where(x => x.CategoryId == request.CategoryId).ToList();
            }
            List<ProductDTO> _products = _mapper.Map<List<ProductDTO>>(queryProduct);
            return _products;
            
        }

        public async Task Update(ProductCreateUpdateDTO entity)
        {
            await _productDAO.Update(_mapper.Map<Product>(entity), "CreatedAt");
        }
    }
}
