using _04.Services.Dto;
using _04.Service.Interfaces;
using _02.Data.Interfaces;
using _01.Core.Entities;
using AutoMapper;
using System.CodeDom;

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

        public async Task<TournamentDto> CreateTournament(TournamentDto tournamentDto){

            var entity = _mapper.Map<Tournament>(tournamentDto);

            var result = await _repository.Create(entity);

            return _mapper.Map<TournamentDto>(result);
        } 


         public async Task<TournamentDto> UpdateTournament(TournamentDto tournamentDto){

            var entity = _mapper.Map<Tournament>(tournamentDto);
            if(entity == null) throw new Exception("Torneio não encontrado!");

            var result = await _repository.Update(entity);

            return _mapper.Map<TournamentDto>(result);
        } 

        public async Task RemoveTournament(Guid id){
            await _repository.Remove(id);
        }
        
        public async Task<ICollection<Tournament>> GetAll(){
            return await _repository.GetAll();
        }
    }
}