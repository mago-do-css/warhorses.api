using _04.Services.Dto;
using _04.Service.Interfaces; 


namespace _04.Service.Services
{
    public class TournamentService : ITournamentService
    {
       // private readonly ITournamentRepository _reposito;
        public TournamentService()
        {
        }

        public Task<TournamentDto> CreateTournament(TournamentDto data){

           data.Id = Guid.NewGuid().ToString();

           return  Task.FromResult(new TournamentDto(){
                    Id = data.Id,
                    Description = data.Description,
                    Date = data.Date
                });
        }

    }
}