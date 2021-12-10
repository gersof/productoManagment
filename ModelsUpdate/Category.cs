using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProductManagment.ModelsUpdate
{
    public class Category
    {
        [Key]
        [Column("idCategory")]
        [StringLength(50)]
        public Guid IdCategory { get; set; }
        public string Name { get; set; }

        public ICollection<CategoriesXproduct> CategoriesXproducts { get; set; }
    }
}
