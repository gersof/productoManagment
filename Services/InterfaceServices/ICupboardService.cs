using ApiProductManagment.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProductManagment.Services.InterfaceServices
{
    public interface ICupboardService
    {
        Task<IEnumerable<CupboardDto>> ConsultCupboards(); 
        CupboardDto ConsultCupboard(Guid id);
        CreateCupBoardDto CreateCupboards(CreateCupBoardDto cupboard);  
        Task<CreateCupBoardDto> UpdateCupboard(Guid id, CreateCupBoardDto cupboard);
        Task<UserXCupboardDto> UploadUserXCupBoard(string idUser, Guid IdCupboard); 
        Task<CupboardDto> DeleteCupBoard(Guid id); 
    }
}
