using _04.Services.Dto;

namespace _04.Service.Interfaces
{
    public interface ITournamentService
    {
        Task<TournamentDto> CreateTournament(TournamentDto data); 
    
    }
} 