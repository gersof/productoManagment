using System;

namespace ApiProductManagment.ModelsUpdate
{
    public class CategoriesXproduct
    {
        public Guid IdCategoryXproduct { get; set; }
        public Guid IdCategory { get; set; }
        public Guid IdProduct { get; set; }
        
        public Category Category { get; set; }
       
        public Product Product { get; set; } 
    }
}
