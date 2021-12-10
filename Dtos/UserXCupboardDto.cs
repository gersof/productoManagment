using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Dtos
{
    public class UserXCupboardDto
    {
        public Guid IdUserXcupboard { get; set; }
        public string IdUser { get; set; }
        public Guid IdCupBoard { get; set; }
    }
}
