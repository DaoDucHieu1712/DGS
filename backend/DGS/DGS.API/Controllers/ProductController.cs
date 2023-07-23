using DGS.BusinessObjects.DTOs.Product;
using DGS.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Reflection.Metadata.Ecma335;

namespace DGS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                return StatusCode(200, await productRepository.GetAll());
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                var product = await productRepository.FindById(id);
                return Ok(product);
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(ProductCreateUpdateDTO request)
        {
            try
            {
                await productRepository.Add(request);
                return NoContent();
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddMultiple")]
        public async Task<IActionResult> AddMultiple(List<ProductCreateUpdateDTO> request)
        {
            try
            {
                await productRepository.AddMultiple(request);
                return NoContent();
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductCreateUpdateDTO request)
        {
            try
            {
                request.Id = id;
                await productRepository.Update(request);
                return NoContent();
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await productRepository.Remove(id);
                return NoContent();
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Filter")]
        public async Task<IActionResult> Filter([FromQuery] ProductFilterDTO request)
        {
            try
            {
                return Ok(await productRepository.Filter(request));
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery] ProductFilterDTO request)
        {
            try
            {
                return Ok(await productRepository.Search(request));
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Export")]
        public async Task ExportExcell()
        {

            List<ProductDTO> products = await productRepository.GetAll();
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
                    worksheet.Cells[i + 2, 7].Value = products[i].IsActive;
                }


                // Set the content type and filename for the response
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.Headers.Add("Content-Disposition", "attachment; filename=exported_data.xlsx");

                // Write the Excel file to the response stream asynchronously
                await Response.Body.WriteAsync(package.GetAsByteArray());

            }

        }

    }
}

