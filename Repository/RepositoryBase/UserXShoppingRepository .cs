using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.Interfaces;

namespace ApiProductManagment.Repository.RepositoryBase
{
    public class UserXShoppingRepository : RepositoryBase<UserXshoppingList>, IUserXShoppingRepository 
    {
        public UserXShoppingRepository(CupboardContext context) : base(context)
        {
        }
    }
}
