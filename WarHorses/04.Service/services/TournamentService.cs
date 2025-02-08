using _04.Services.Dto;
using _04.Service.Interfaces;
using _02.Data.Interfaces;
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

        public async Task<TournamentDto> Create(TournamentDto tournamentDto){

            var entity = _mapper.Map<Tournament>(tournamentDto);

            var result = await _repository.Create(entity);

            return _mapper.Map<TournamentDto>(result);
        } 


         public async Task<TournamentDto> Update(TournamentDto tournamentDto){

            var entity = _mapper.Map<Tournament>(tournamentDto);
            if(entity == null) throw new Exception("Torneio não encontrado!");

            var result = await _repository.Update(entity);

            return _mapper.Map<TournamentDto>(result);
        } 

        public async Task Remove(Guid id){
            try{
                 await _repository.Remove(id);
            }catch(Exception e){
                throw new Exception("Erro ao remover torneio.", e);
            } 
        }
 
        public async Task<ICollection<TournamentDto>> GetAll(){
            var list =  await _repository.GetAll();

            return _mapper.Map<ICollection<TournamentDto>>(list);
        } 
        
        public async Task<TournamentDto> GetById(Guid id)
        {
            var entity = await _repository.GetById(id); 

            return _mapper.Map<TournamentDto>(entity);
        }
    }
}