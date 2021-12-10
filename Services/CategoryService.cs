using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.Interfaces;
using ApiProductManagment.Services.InterfaceServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProductManagment.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public IEnumerable<CategoryDto> GetCategories()
        {
            var categoriesDb = _repository.Queries();
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categoriesDb);
            return categoriesDto;
        }

        public CategoryDto GetCategory(Guid id)
        {
            var categoryDb = _repository.QueryById(c => c.IdCategory == id);
            if (categoryDb != null)
            {
                return _mapper.Map<CategoryDto>(categoryDb);
            }
            throw new Exception("Error reading Category");
        }

        public async Task<CategoryDto> CreateCategory(EditingCategoryDto category)
        {
            var categoryDb = _mapper.Map<Category>(category);
            await _repository.Create(categoryDb);
            var response = _mapper.Map<CategoryDto>(categoryDb);
            return response; 
        }

        public async Task<EditingCategoryDto> UploadCategory(Guid id, EditingCategoryDto category)
        {
            var categoryDb = _repository.QueryById(c => c.IdCategory == id);
            if (categoryDb != null)
            {
                categoryDb.Name = category.Name;
                // var upCategory = _mapper.Map<Category>(category);
                await _repository.Upload(categoryDb);
                var response = _mapper.Map<EditingCategoryDto>(categoryDb);
                return response;
            }
            else
            {
            throw new Exception("Error editing Category");
            }
        }

        public async Task<CategoryDto> DeleteCategory(Guid id)
        {
            var categoryDb = _repository.QueryById(c => c.IdCategory == id);
            if (categoryDb != null)
            {
                await _repository.Delete(categoryDb);
                var response = _mapper.Map<CategoryDto>(categoryDb);
                return response;
            }
            else
            {
            throw new Exception("Error deleting Category");
            }
        }
    }
}
