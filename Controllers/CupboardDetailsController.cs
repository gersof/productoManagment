using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using ApiProductManagment.Services.InterfaceServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiProductManagment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CupboardDetailsController : ControllerBase
    {
        private readonly ICupboardDetailService _cupboardDetailService;
        private readonly IMapper _mapper;

        public CupboardDetailsController(ICupboardDetailService service, IMapper mapper)
        {
            _cupboardDetailService = service;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var cupboardDetailsDto = _cupboardDetailService.GetCupboardDetails();
            return Ok(cupboardDetailsDto);
        }


        [HttpGet("{id}")]
        public ActionResult<CupboardDetailDto> GetCupboardDetail(Guid id)
        {
            return _cupboardDetailService.GetCupboardDetail(id);
        }


        [HttpGet("valid-products")]
        public IActionResult GetValidProducts()
        {
            var cupboardDetailsDto = _cupboardDetailService.GetValidProducts();
            return Ok(cupboardDetailsDto);
        }  
        
        
        [HttpGet("expired-products")]
        public IActionResult GetExpiredProducts()
        {
            var cupboardDetailsDto = _cupboardDetailService.GetExpiredProducts();
            return Ok(cupboardDetailsDto);
        } 

        
        [HttpGet("productsNextToExpire")]
        public IActionResult GetNextToExpire()
        {
            var cupboardDetailsDto = _cupboardDetailService.GetNextToExpire();
            return Ok(cupboardDetailsDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, CupboardDetailPutDto cupboardDetailDto)
        {
            var resultDto = await _cupboardDetailService.UploadCupboardDetail(id, cupboardDetailDto);
            return Ok(resultDto);
        }


        /*[HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _cupboardDetailService.DeleteCupboardDetail(id);
            return Ok(response);
        }*/

    }
}
