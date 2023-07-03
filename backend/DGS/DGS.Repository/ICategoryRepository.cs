using DGS.BusinessObjects.DTOs.Category;
using DGS.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.Repository
{
    public interface ICategoryRepository : IRepository<CategoryDTO, CategoryCreateUpdateDTO, int>
    {
    }
}
