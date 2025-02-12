using _04.Services.Dto;

namespace _04.Service.Interfaces
{
    public interface IDuelService : IService<DuelDto>
    {
      Task<DuelDto> FinishDuel(DuelDto dutelDto);
    }
} 