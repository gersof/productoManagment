using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using ApiProductManagment.Repository.Interfaces;
using ApiProductManagment.Services.InterfaceServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductManagment.Services
{
    public class CupboardDetailService : ICupboardDetailService
    {
        private readonly ICupboardDetailRepository _repository;
        private readonly IMapper _mapper;

        public CupboardDetailService(ICupboardDetailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public IEnumerable<CupboardDetailDto> GetCupboardDetails()
        {
            var CupboardDetailDb = _repository.Queries().Include(x => x.Product).Include(x => x.CupBoard);
            var CupboardDetailDto = _mapper.Map<IEnumerable<CupboardDetailDto>>(CupboardDetailDb);
            return CupboardDetailDto;
        } 


        public CupboardDetailDto GetCupboardDetail(Guid id)
        {
            var CupboardDetailDb = _repository.QueryById(x => x.IdCupboardDetail == id);
            if (CupboardDetailDb != null)
            {
                return _mapper.Map<CupboardDetailDto>(CupboardDetailDb);
            }
            throw new Exception("Error reading Cupboard Detail"); ;
        }


        public IEnumerable<CupboardDetailDto> GetValidProducts()
        {
            //var date = DateTime.Now;
            //var range = date.AddDays(1);
            var CupboardDetailDb = _repository.Queries().Include(x => x.Product).Include(x => x.CupBoard).Where(x => x.ExpirationDate >= DateTime.Now);
            var CupboardDetailDto = _mapper.Map<IEnumerable<CupboardDetailDto>>(CupboardDetailDb);
            return CupboardDetailDto;
        }


        public IEnumerable<CupboardDetailDto> GetExpiredProducts()
        {
            var CupboardDetailDb = _repository.Queries().Include(x => x.Product).Include(x => x.CupBoard).Where(x => x.ExpirationDate < DateTime.Now);
            var CupboardDetailDto = _mapper.Map<IEnumerable<CupboardDetailDto>>(CupboardDetailDb);
            return CupboardDetailDto;
        }        
        

        public IEnumerable<CupboardDetailDto> GetNextToExpire()
        {
            var date = DateTime.Now;
            var range = date.AddDays(5);
            var CupboardDetailDb = _repository.Queries().Include(x => x.Product).Include(x => x.CupBoard).Where(x => x.ExpirationDate < range && x.ExpirationDate >= DateTime.Now);
            var CupboardDetailDto = _mapper.Map<IEnumerable<CupboardDetailDto>>(CupboardDetailDb);
            return CupboardDetailDto;
        }


        public async Task<CupboardDetailPutDto> UploadCupboardDetail(Guid id, CupboardDetailPutDto cupboardDetailDto)
        {
            var CupboardDetailDb = _repository.QueryById(x => x.IdCupboardDetail == id);
            if (CupboardDetailDb != null)
            {  
                var updateDetail = _mapper.Map(cupboardDetailDto, CupboardDetailDb);
                await _repository.Upload(updateDetail);
                var response = _mapper.Map<CupboardDetailPutDto>(CupboardDetailDb);
                return response;
            }
            else
            {
                throw new Exception("Error editing Cupboard Detail");
            }
        }


        public async Task<CupboardDetailDto> DeleteCupboardDetail(Guid id)
        {
            var CupboardDetailDb = _repository.QueryById(x => x.IdCupboardDetail == id);
            if (CupboardDetailDb != null)
            {
                await _repository.Delete(CupboardDetailDb);
                var response = _mapper.Map<CupboardDetailDto>(CupboardDetailDb);
                return response;
            }
            else
            {
                throw new Exception("Error deleting Cupboard Detail");
            }
        }

    }
}
