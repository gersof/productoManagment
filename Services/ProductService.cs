using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.Interfaces;
using ApiProductManagment.Services.InterfaceServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryXProductRepository _categoryXProductRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, ICategoryRepository category, 
                               ICategoryXProductRepository categoryXProductRepository, IMapper mapper
        )
        {
            _repository = repository;
            _categoryRepository = category;
            _categoryXProductRepository = categoryXProductRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            var productsDb =  _repository.Queries().Include(x => x.Trademark);
            var productsDto = _mapper.Map<IEnumerable<ProductDto>> (productsDb);
            return productsDto;
        }

        public ProductDto GetProduct(Guid id)
        {
            var productDb = _repository.QueryById(p => p.IdProduct == id);
            if (productDb != null)
            {
                return _mapper.Map<ProductDto>(productDb);
            }
            throw new Exception("Error reading Product");
        }

        public async Task<ProductDto> CreateProduct(PostProductDto product)
        {
            var productDb = _mapper.Map<Product>(product);
            await _repository.Create(productDb);
            var response = _mapper.Map<ProductDto>(productDb);
            return response;
        }

        public async Task<PutProductDto> UploadProduct(Guid id, PutProductDto product)
        {
            var productDb = _repository.QueryById(p => p.IdProduct == id);
            if (productDb != null)
            {
                productDb.NameProduct = product.NameProduct;
                productDb.IdMark = (Guid)product.IdMark;
                productDb.BarCode = product.BarCode;

                await _repository.Upload(productDb);
                var response = _mapper.Map<PutProductDto>(productDb);
                return response;
            }
            else
            {
                throw new Exception("Error editing Product");
            }
        }

        public async Task<ProductDto> DeleteProduct(Guid id)
        {
            var productDb = _repository.QueryById(p => p.IdProduct == id);
            if (productDb != null)
            {
                await _repository.Delete(productDb);
                var response = _mapper.Map<ProductDto>(productDb);
                return response;
            }
            else
            {
                throw new Exception("Error deleting Category");
            }
        }

        public async Task<CategoriesXproductsDto> UploadCategoryXProduct(Guid idCategory, Guid idProduct)
        {
            var category =  _categoryRepository.QueryById(x => x.IdCategory == idCategory);
            if (category == null) throw new Exception("La categoria no existe.");

            var product = _repository.QueryById(x => x.IdProduct == idProduct);
            if (product == null) throw new Exception("La producto no existe.");

            var categoryxproduct = new CategoriesXproduct()
            {
                IdCategory = category.IdCategory,
                IdProduct = product.IdProduct
            };

            await _categoryXProductRepository.Upload(categoryxproduct);
            var result = _mapper.Map<CategoriesXproductsDto>(categoryxproduct);
            return result;
        }
    }
}
