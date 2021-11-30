using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.Interfaces;

namespace ApiProductManagment.Repository.RepositoryBase
{
    public class CategoryXProductRepository : RepositoryBase<CategoriesXproduct>, ICategoryXProductRepository 
    {
        public CategoryXProductRepository(CupboardContext context) : base(context) 
        {
        }
    }
}
