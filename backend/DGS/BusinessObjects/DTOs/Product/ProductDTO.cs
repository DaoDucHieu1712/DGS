using DGS.BusinessObjects.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DGS.BusinessObjects.DTOs.Product
{
    public class ProductDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsActive { get; set; }

        public CategoryDTO Category { get; set; }
    }
}
