using _04.Services.Dto;
using _04.Service.Interfaces;
using _02.Data.Interfaces;
using _01.Core.Entities;
using AutoMapper; 

namespace _04.Service.Services
{
    public class DuelService : IDuelService
    {
       private readonly IDuelRepository _repository; 
       private readonly IMapper _mapper; 

        public DuelService(IDuelRepository repository, IMapper mapper)
        {
            _repository = repository; 
            _mapper = mapper;
        } 

        public async Task<DuelDto> Create(DuelDto duelDto){

            var entity = _mapper.Map<Duel>(duelDto);

            var result = await _repository.Create(entity);

            return _mapper.Map<DuelDto>(result);
        } 

 
         public async Task<DuelDto> Update(DuelDto duelDto){

            var entity = await _repository.GetById(duelDto.Id);
            if(entity == null) throw new Exception("Torneio não encontrado!");

            _mapper.Map(duelDto, entity);

            var result = await _repository.Update(entity);

            return _mapper.Map<DuelDto>(result);
        } 

        public async Task Remove(Guid id){
            try{
                 await _repository.Remove(id);
            }catch(Exception e){
                throw new Exception("Erro ao remover torneio.", e);
            } 
        }

        public async Task<DuelDto> FinishDuel(DuelDto dutelDto){
            try{
               var duel = _mapper.Map<Duel>(dutelDto);

              var result = await _repository.FinishDuel(duel);
           
              return _mapper.Map<DuelDto>(dutelDto);

            }catch(Exception e){
                throw new Exception("Erro ao finalizar duelo.", e);
            } 
        }
 
        public async Task<ICollection<DuelDto>> GetAll(){
            var list =  await _repository.GetAll();

            return _mapper.Map<ICollection<DuelDto>>(list);
        } 
        
        public async Task<DuelDto> GetById(Guid id)
        {
            var entity = await _repository.GetById(id); 

            return _mapper.Map<DuelDto>(entity);
        }
    }
}