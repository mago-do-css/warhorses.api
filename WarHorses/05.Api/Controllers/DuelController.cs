
using _04.Service.Interfaces;
using _04.Services.Dto;
using Microsoft.AspNetCore.Mvc; 

namespace _05.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DuelController : Controller
    { 
        private readonly IDuelService _service;

        public DuelController(IDuelService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<DuelDto> CreateDuel([FromBody] DuelDto request)
        { 
           return await _service.Create(request);
        }

        [HttpPost("update")]
        public async Task<DuelDto> UpdateDuel([FromBody] DuelDto request )
        { 
           return await _service.Update(request);
        }

        [HttpPost("remove/{id}")]
        public Task RemoveDuel([FromRoute] Guid id)
        { 
           return _service.Remove(id);
        }

          [HttpPost("finish/{id}")]
        public Task FinishDuel([FromBody] DuelDto duelDto)
        { 
           return _service.FinishDuel(duelDto);
        }


        [HttpGet("get/{id}")]
        public async Task<DuelDto> GetById(Guid id)
        {
            return await _service.GetById(id); 
        }
        [HttpGet("get-list")]
        public async Task<ICollection<DuelDto>> GetAllDuel()
        {
            return await _service.GetAll(); 
        }
    }
}