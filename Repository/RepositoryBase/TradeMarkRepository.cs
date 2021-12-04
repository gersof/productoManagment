using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.Interfaces;
using AutoMapper;

namespace ApiProductManagment.Repository.RepositoryBase
{
    public class TradeMarkRepository : RepositoryBase<Trademark>, ITrademarkRepository
    {
        public CupboardContext CupboardContext { get; set; }

        public TradeMarkRepository(CupboardContext context) : base(context)
        {
            CupboardContext = context;
        }
    }
}
