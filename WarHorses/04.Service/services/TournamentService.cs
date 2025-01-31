using _04.Services.Dto;
using _04.Service.Interfaces;
using _02.Data.FirebaseRepository;
using _01.Core.Entities;


namespace _04.Service.Services
{
    public class TournamentService : ITournamentService
    {
       private readonly ITournamentRepository _repository;
        public TournamentService(ITournamentRepository repository)
        {
            _repository = repository;
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