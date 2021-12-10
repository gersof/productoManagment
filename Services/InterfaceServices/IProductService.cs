using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Services.InterfaceServices
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProducts();
        ProductDto GetProduct(Guid id);
        Task<ProductDto> CreateProduct(PostProductDto product);
        Task<PutProductDto> UploadProduct(Guid id, PutProductDto product);
        Task<CategoriesXproductsDto> UploadCategoryXProduct(Guid idCategory, Guid IdProduct);
        Task<ProductDto> DeleteProduct(Guid id);
    }
}
