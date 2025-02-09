
using _04.Service.Interfaces;
using _04.Services.Dto;
using Microsoft.AspNetCore.Mvc; 

namespace _05.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentController : Controller
    { 
        private readonly ITournamentService _service;

        public TournamentController(ITournamentService service)
        {
            _service = service;
        }

        [HttpPost("create-tournament")]
        public async Task<TournamentDto> CreateTournament([FromBody] TournamentDto request)
        { 
           return await _service.Create(request);
        }

        [HttpPost("update-tournament")]
        public async Task<TournamentDto> UpdateTournament([FromBody] TournamentDto request )
        { 
           return await _service.Update(request);
        }

        [HttpPost("remove-tournament")]
        public Task RemoveTournament([FromRoute] Guid tournamentId)
        { 
           return _service.Remove(tournamentId);
        }

        [HttpGet("get-tournament/{id}")]
        public async Task<TournamentDto> GetTournament(Guid id)
        {
            return await _service.GetById(id); 
        }
        [HttpGet("get-list-tournament")]
        public async Task<ICollection<TournamentDto>> GetAllTournament()
        {
            return await _service.GetAll(); 
        }
    }
}
