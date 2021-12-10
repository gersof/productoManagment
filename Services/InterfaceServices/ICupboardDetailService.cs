using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Services.InterfaceServices
{
    public interface ICupboardDetailService
    {
        IEnumerable<CupboardDetailDto> GetCupboardDetails();
        CupboardDetailDto GetCupboardDetail(Guid id);
        IEnumerable<CupboardDetailDto> GetValidProducts();
        IEnumerable<CupboardDetailDto> GetExpiredProducts();
        IEnumerable<CupboardDetailDto> GetNextToExpire();
        Task<CupboardDetailPutDto> UploadCupboardDetail(Guid id, CupboardDetailPutDto cupboardDetailDto);
        Task<CupboardDetailDto> DeleteCupboardDetail(Guid id);
    }
}
