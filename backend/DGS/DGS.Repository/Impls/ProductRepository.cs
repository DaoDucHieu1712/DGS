using AutoMapper;
using DGS.BusinessObjects.DTOs.Product;
using DGS.BusinessObjects.Entities;
using DGS.DataAccess.impls;
using DGS.DataAccess.interfaces;
using DGS.Repository.Helper;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Xml;


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

        public async Task ExportExcel()
        {
            List<ProductDTO> products = _mapper.Map<List<ProductDTO>>(await _productDAO.FindAll(x => x.Category).ToListAsync());
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                worksheet.Cells[1, 1].Value = "Id";
                worksheet.Cells[1, 2].Value = "ProductName";
                worksheet.Cells[1, 3].Value = "ImageUrl";
                worksheet.Cells[1, 4].Value = "Description";
                worksheet.Cells[1, 5].Value = "Price";
                worksheet.Cells[1, 6].Value = "Category";
                worksheet.Cells[1, 7].Value = "IsActive";

                for (int i = 0; i < products.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = products[i].Id;
                    worksheet.Cells[i + 2, 2].Value = products[i].Name;
                    worksheet.Cells[i + 2, 3].Value = products[i].Image;
                    worksheet.Cells[i + 2, 4].Value = products[i].Description;
                    worksheet.Cells[i + 2, 5].Value = products[i].Price;
                    worksheet.Cells[i + 2, 6].Value = products[i].Category.Name;
                    worksheet.Cells[i + 2, 6].Value = products[i].IsActive;
                }


                //// Set the content type and filename for the response
                //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //Response.Headers.Add("Content-Disposition", "attachment; filename=exported_data.xlsx");

                //// Write the Excel file to the response stream asynchronously
                //await Response.Body.WriteAsync(package.GetAsByteArray());

            }
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
