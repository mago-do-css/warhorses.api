
using _02.Data.FirebaseRepository;
using Microsoft.AspNetCore.Mvc; 

namespace _05.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FirebaseController : Controller
    { 
        private readonly ITesteRepoRepository _firebaseRepository;

        public FirebaseController(ITesteRepoRepository firebaseRepository)
        {
            _firebaseRepository = firebaseRepository;
        }

        // private readonly TesteRepo _firebaseRepository;
       
        // public FirebaseController(TesteRepo firebaseRepository)
        // {
        //     _firebaseRepository = firebaseRepository;
        // }

        [HttpPost("add")]
        public async Task<IActionResult> AddDocument([FromBody] object data)
        {
            await _firebaseRepository.AddDocumentAsync("Teste", Guid.NewGuid().ToString(), data);
            return Ok(new { message = "Documento adicionado com sucesso!" });
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetDocument(string id)
        {
             var document = await _firebaseRepository.GetDocumentAsync("Teste", id);
            return document != null ? Ok(document) : NotFound(new { message = "Documento não encontrado!" });
        }
    }
}
