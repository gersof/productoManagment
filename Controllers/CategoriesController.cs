using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using ApiProductManagment.Services.InterfaceServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;



namespace ApiProductManagment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {


        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryservice, IMapper mapper)
        {
            _categoryService = categoryservice;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var categories =  _categoryService.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetCategory(Guid id)
        {
            return _categoryService.GetCategory(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EditingCategoryDto category)
        {
            var resultcategory = await _categoryService.CreateCategory(category);
            return Ok(resultcategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, EditingCategoryDto category)
        {
            var categoryresult = await _categoryService.UploadCategory(id, category);
            return Ok(categoryresult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _categoryService.DeleteCategory(id);
            return Ok(response);
        }
    }
}
