using ApiProductManagment.ModelsUpdate;
using System;

namespace ApiProductManagment.Dtos
{
    public class ShoppingListDto
    {
        public Guid IdShopping { get; set; }
        public Guid IdProduct { get; set; }
        public int? Amount { get; set; }
        public decimal? Value { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public Product Product { get; set; }
    }
}
