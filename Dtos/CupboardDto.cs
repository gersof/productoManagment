using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Dtos
{
    public class CupboardDto
    {
        public Guid IdCupBoard { get; set; }
        public string NameCupBoard { get; set; }
        public bool? IsDefault { get; set; }
        public DateTime? CreationDate { get; set; }

        //public List<CupboardDetailDto> CupBoardDetails { get; set; }
    }
}
