using _04.Services.Dto;
using _04.Service.Interfaces;
using _02.Data.FirebaseRepository;
using _01.Core.Entities;
using AutoMapper;

namespace _04.Service.Services
{
    public class TournamentService : ITournamentService
    {
       private readonly ITournamentRepository _repository; 
       private readonly IMapper _mapper; 

        public TournamentService(ITournamentRepository repository, IMapper mapper)
        {
            _repository = repository; 
            _mapper = mapper;
        } 

        public async Task<TournamentDto> CreateTournament(TournamentDto data){

            var tournament = _mapper.Map<Tournament>(data);

            var result = await _repository.AddTournament(tournament);

            return _mapper.Map<TournamentDto>(result);
        } 
    }
}