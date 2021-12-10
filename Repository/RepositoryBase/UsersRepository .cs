using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.Interfaces;

namespace ApiProductManagment.Repository.RepositoryBase
{
    public class UsersRepository : RepositoryBase<Users>, IUserRepository 
    {
        public UsersRepository(CupboardContext context) : base(context) 
        {
        }
    }
}
