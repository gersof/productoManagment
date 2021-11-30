using System;

namespace ApiProductManagment.Dtos
{
    public class UserXshoppingListDto
    {
        public Guid IdUserXshopping { get; set; }
        public string IdUser { get; set; }
        public Guid IdShopping { get; set; }
    }
}
