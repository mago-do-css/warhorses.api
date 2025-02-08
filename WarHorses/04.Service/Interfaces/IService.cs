using _04.Services.Dto;

namespace _04.Service.Interfaces
{
    public interface IService<T>
    {
        Task<T> Create(TournamentDto data);
        Task<T> Update(TournamentDto tournamentDto);
        Task Remove(Guid id);
        Task<ICollection<T>> GetAll();
        Task<T> GetById(Guid id); 
    }
} 