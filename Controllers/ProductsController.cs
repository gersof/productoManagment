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
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper     = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct(Guid id)
        {
            return _productService.GetProduct(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostProductDto product)
        {
            var resultproduct = await _productService.CreateProduct(product);
            return Ok(resultproduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, PutProductDto product)
        {
            var productresult = await _productService.UploadProduct(id, product);
            return Ok(productresult);
        }

        [HttpPut("assign-category-product")]
        public async Task<IActionResult> UpdateCategoryProduct(Guid IdCategory, Guid idProduct)  
        {
            var result = await _productService.UploadCategoryXProduct(IdCategory,idProduct); 
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _productService.DeleteProduct(id);
            return Ok(response);
        }
    }
}
