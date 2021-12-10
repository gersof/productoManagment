using ApiProductManagment.Dtos;
using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.Interfaces;
using AutoMapper;
using System;

namespace ApiProductManagment.Repository.RepositoryBase
{
    public class RepositoryCupBoard: RepositoryBase<CupBoard>, IRepositoryCupboard
    {
        public CupboardContext CupBoardContext { get; set; }
        private readonly IMapper _mapper;

        public RepositoryCupBoard(CupboardContext context, IMapper mapper) : base(context)
        {
            CupBoardContext = context;
            _mapper = mapper;
        }

        public CupBoard CreateCupBoard(CreateCupBoardDto cupboard)
        {
            using var transaction = CupBoardContext.Database.BeginTransaction();

            var tableCupboard = new CupBoard();
            try
            {
                tableCupboard = _mapper.Map<CupBoard>(cupboard);

                CupBoardContext.CupBoards.Add(tableCupboard);
                CupBoardContext.SaveChanges();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("No se guardaron los cambios", ex);
            }
            return tableCupboard;
        }
    }
}
