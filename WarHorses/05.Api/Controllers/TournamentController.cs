
using _02.Data.FirebaseRepository;
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
           return await _service.CreateTournament(request);
        }

        [HttpPost("update-tournament")]
        public async Task<TournamentDto> UpdateTournament([FromRoute] int tournamentId)
        { 
           return await _service.UpdateTournament(tournamentId);
        }

        [HttpPost("remove-tournament")]
        public async Task<TournamentDto> RemoveTournament([FromRoute] int tournamentId)
        { 
           return await _service.RemoveTournament(tournamentId);
        }

        // [HttpGet("get/tournament/{id}")]
        // public async Task<IActionResult> GetDocument(string id)
        // {
        //      var document = await _firebaseRepository.GetDocumentAsync("Teste", id);
        //     return document != null ? Ok(document) : NotFound(new { message = "Documento não encontrado!" });
        // }
    }
}
