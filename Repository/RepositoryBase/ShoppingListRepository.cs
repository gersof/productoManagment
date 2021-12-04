using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.Interfaces;

namespace ApiProductManagment.Repository.RepositoryBase
{
    public class ShoppingListRepository : RepositoryBase<ShoppingList>, IShoppingListRepository
    {
        public CupboardContext CupboardContext { get; set; }

        public ShoppingListRepository(CupboardContext context) : base(context)
        {
            CupboardContext = context;
        }
    }
}
