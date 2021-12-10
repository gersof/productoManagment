using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Dtos.EditingDtos
{
    public class PutProductDto
    {
        public string NameProduct { get; set; }
        public Guid? IdMark { get; set; }
        public string BarCode { get; set; }
    }
}
