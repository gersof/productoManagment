using System;

namespace ApiProductManagment.ModelsUpdate
{
    public partial class UserXcupBoard
    {
        public Guid IdUserXCupBoard { get; set; } 
        public string IdUser { get; set; }
        public Guid IdCupBoard { get; set; }

        public CupBoard CupBoard { get; set; }
        public Users User { get; set; } 
    }
}
