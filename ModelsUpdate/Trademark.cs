using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProductManagment.ModelsUpdate
{
    public class Trademark
    {
        public Guid IdTrademark { get; set; }
        public string Mark { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
