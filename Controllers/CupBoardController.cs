using ApiProductManagment.Dtos;
using ApiProductManagment.Services.InterfaceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiProductManagment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CupBoardController : ControllerBase
    {
       private readonly ICupboardService _cupBoardService;
            

       public CupBoardController(ICupboardService cupboard)
       {
         _cupBoardService = cupboard;
       }

        [HttpGet]
        public async Task<IActionResult> ConsultCupBoards()
        {
            var cupbard = await _cupBoardService.ConsultCupboards(); 
            return Ok(cupbard);
        }

        [HttpGet("{id}")]
        public IActionResult ConsulById(Guid id)
        {
            var cupbard = _cupBoardService.ConsultCupboard(id);
            return Ok(cupbard);
        }

        [HttpPost("Create-cupboard-Detail")]
        public  IActionResult CreateCupBoardDetail(CreateCupBoardDto cupboard)
        { 
          var response =  _cupBoardService.CreateCupboards(cupboard);     
           return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCupBoards (Guid id, CreateCupBoardDto cupboard)
        {
           var result = await _cupBoardService.UpdateCupboard(id, cupboard);
           return Ok(result);
        }

        [HttpPut("assign-User-cupboard")]
        public async Task<IActionResult> UpdateUserXCupBoard(string idUser, Guid idCupBoard)
        {
            var result = await _cupBoardService.UploadUserXCupBoard(idUser, idCupBoard);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCupboard(Guid id)
        {
            var result = await _cupBoardService.DeleteCupBoard(id);
            return Ok(result);
        }

    }
}
