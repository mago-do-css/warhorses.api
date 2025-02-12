using _01.Core.Entities;

namespace _02.Data.Interfaces
{
    public interface IDuelRepository : IRepository<Duel>
    { 
        public Task<Duel> FinishDuel(Duel duel);
    }
} 