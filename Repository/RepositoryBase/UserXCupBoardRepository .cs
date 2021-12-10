using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.Interfaces;

namespace ApiProductManagment.Repository.RepositoryBase
{
    public class UserXCupBoardRepository : RepositoryBase<UserXcupBoard>, IUserXCupBoardRepository 
    {
        public UserXCupBoardRepository(CupboardContext context) : base(context)  
        {
        }
    }
}
