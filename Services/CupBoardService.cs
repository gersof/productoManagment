using ApiProductManagment.Dtos;
using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.Interfaces;
using ApiProductManagment.Services.InterfaceServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProductManagment.Services
{
    public class CupBoardService : ICupboardService
    {
        private readonly IRepositoryCupboard _repositoryCupBoard;
        private readonly IUserRepository _userRepository;
        private readonly IUserXCupBoardRepository _userXCupBoardRepository;
        private readonly IMapper _mapper;
        public CupBoardService(IRepositoryCupboard cupboard,IUserRepository userRepository, 
                                IUserXCupBoardRepository userXCupBoardRepository, IMapper mapper
        )
        {
            _repositoryCupBoard = cupboard;
            _userRepository = userRepository;
            _userXCupBoardRepository = userXCupBoardRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CupboardDto>> ConsultCupboards()
        {
            var result =   _repositoryCupBoard.Queries();
            var resultdto = _mapper.Map<IEnumerable<CupboardDto>>(result);
            return resultdto;
        }
        public CupboardDto ConsultCupboard(Guid id)
        {
            var cupboardbd = _repositoryCupBoard.QueryById(s => s.IdCupBoard == id);
            if (cupboardbd != null)
            {
                return _mapper.Map<CupboardDto>(cupboardbd);
            }
            else
            {
                throw new Exception ("El CupBoard que solicita no existe en la base de datos." );
            }
        }

        public CreateCupBoardDto CreateCupboards(CreateCupBoardDto cupboard) 
        {
            var result = _repositoryCupBoard.CreateCupBoard(cupboard);
            cupboard = _mapper.Map<CreateCupBoardDto>(result);
            return cupboard;
        }

        public async Task<CreateCupBoardDto> UpdateCupboard(Guid id, CreateCupBoardDto cupboard)
        {
            var cupboardbd = _repositoryCupBoard.QueryById(s => s.IdCupBoard == id);
            if (cupboardbd != null)
            {
                cupboardbd.NameCupBoard = cupboard.NameCupBoard ?? cupboardbd.NameCupBoard;
                cupboardbd.IsDefault = cupboard.IsDefault ?? cupboardbd.IsDefault;
                cupboardbd.CreationDate = cupboard.CreationDate ?? cupboardbd.CreationDate;

                await _repositoryCupBoard.Upload(cupboardbd);
                var cupboardAut = _mapper.Map<CreateCupBoardDto>(cupboardbd);
                return cupboardAut;
            }
            else
            {
                throw new Exception( "El servicio que desea actualizarle el estado no existe en la base de datos");
            }
        }
        public async Task<CupboardDto> DeleteCupBoard(Guid id)
        {
            var cupboardbd = _repositoryCupBoard.QueryById(s => s.IdCupBoard == id);
            if (cupboardbd != null)
            {
                try
                {
                    await _repositoryCupBoard.Delete(cupboardbd);
                    var cupboardDelete = _mapper.Map<CupboardDto>(cupboardbd);
                    return cupboardDelete;
                }
                catch (Exception)
                {
                    throw new Exception( "El cupboard tiene relaciones con otros datos no se puede borrar." );
                }
            }
            else
            {
                throw new Exception("El cupboard no existe en la base de datos." );
            }
        }

        public async Task<UserXCupboardDto> UploadUserXCupBoard(string idUser, Guid idCupboard)
        {
            var cupboard = _repositoryCupBoard.QueryById(x => x.IdCupBoard == idCupboard);
            if (cupboard == null) throw new Exception("El cupBoard no existe.");

            var user = _userRepository.QueryById(x => x.Id == idUser);
            if (user == null) throw new Exception("El User no existe.");

            var userxCupboard = new UserXcupBoard()
            {
                IdUser = user.Id,
                IdCupBoard = cupboard.IdCupBoard
            };

            await _userXCupBoardRepository.Upload(userxCupboard);
            var result = _mapper.Map<UserXCupboardDto>(userxCupboard);
            return result;
        }
    }
}
