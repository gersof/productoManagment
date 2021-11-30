using System;
using System.Collections.Generic;


namespace ApiProductManagment.ModelsUpdate
{
    public  class Product
    {
        public Guid IdProduct { get; set; }
        public Guid IdMark { get; set; }
        public string NameProduct { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string BarCode { get; set; }
        public  Trademark Trademark { get; set; }
        
        public ICollection<CategoriesXproduct> CategoriesXproducts { get; set; }
        public  ICollection<CupBoardDetail> CupBoardDetails { get; set; }
        public  ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}
