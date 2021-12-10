using System;
using System.Collections.Generic;

namespace ApiProductManagment.ModelsUpdate
{
    public partial class ShoppingList
    {
        public Guid IdShopping { get; set; }
        public Guid IdProduct { get; set; }
        public int? Amount { get; set; }
        public decimal? Value { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public Product Product { get; set; } 
        public ICollection<UserXshoppingList> UserXshoppingLists { get; set; }
    }
}
