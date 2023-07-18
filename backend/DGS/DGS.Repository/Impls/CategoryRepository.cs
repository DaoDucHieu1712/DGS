using AutoMapper;
using DGS.BusinessObjects.DTOs.Category;
using DGS.BusinessObjects.Entities;
using DGS.DataAccess.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.Repository.Impls
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ICategoryDAO _categoryDAO;
        private readonly IMapper _mapper;

        public CategoryRepository(ICategoryDAO categoryDAO, IMapper mapper)
        {
            _categoryDAO = categoryDAO;
            _mapper = mapper;
        }

        public async Task Add(CategoryCreateUpdateDTO entity)
        {
            await _categoryDAO.Add(_mapper.Map<Category>(entity));
        }

        public async Task<CategoryDTO> FindById(int id)
        {
           return _mapper.Map<CategoryDTO>(await _categoryDAO.FindSingle(e => e.Id == id));
        }

        public async Task<List<CategoryDTO>> GetAll()
        {
            return _mapper.Map<List<CategoryDTO>>(await _categoryDAO.GetList());
        }

        public async Task Remove(int id)
        {
           await _categoryDAO.Remove(id);
        }

        public async Task Update(CategoryCreateUpdateDTO entity)
        {
            await _categoryDAO.Update(_mapper.Map<Category>(entity), "CreatedAt");
        }
    }
}
