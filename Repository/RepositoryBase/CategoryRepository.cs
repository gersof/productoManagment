using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.Interfaces;


namespace ApiProductManagment.Repository.RepositoryBase
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository 
    {
        public CategoryRepository(CupboardContext context) : base(context)
        {
        }
    }
}
