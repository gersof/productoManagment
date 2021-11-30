using System;

namespace ApiProductManagment.ModelsUpdate
{
    public partial class UserXshoppingList
    {
        public Guid IdUserXshopping { get; set; }
        public string IdUser { get; set; }
        public Guid IdShopping { get; set; }

        public ShoppingList Shopping { get; set; } 
        
        public Users User { get; set; }
    }
}
