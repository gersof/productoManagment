using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ApiProductManagment.ModelsUpdate
{
    public class Users: IdentityUser
    {
        public string NombreCompleto { get; set; }


        public ICollection<UserXcupBoard> UserXcupBoards { get; set; }
        public ICollection<UserXshoppingList> UserXshoppingLists { get; set; }
    }
}
