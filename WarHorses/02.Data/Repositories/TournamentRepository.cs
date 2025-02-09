using _01.Core.Entities; 
using _02.Data.Interfaces; 
using Microsoft.EntityFrameworkCore;

namespace _02.Data.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly  WarhosesDbContext _context;
        public TournamentRepository(WarhosesDbContext context)
        { 
            _context = context;
        } 
        
        public async Task<Tournament> GetById(Guid id)
        {
            var entity = await _context.Tournaments.FirstOrDefaultAsync(t=>t.Id == id); 

            if(entity == null) throw new Exception("Torneio nao encontrado!");

            return entity;
        } 

         public async Task<ICollection<Tournament>> GetAll()
        {
            return await _context.Tournaments.Where(t=>t.Active == true).ToListAsync();
        }

        public async Task<Tournament> Create(Tournament tournament){
            var result =  await _context.Tournaments.AddAsync(tournament);
            await _context.SaveChangesAsync();
            return result.Entity;
        } 


        public async Task Remove(Guid id)
        {
            try{ 
                var entity = await _context.Tournaments.FirstOrDefaultAsync(t=>t.Id == id); 

                if(entity == null) throw new Exception("Torneio nao encontrado!");

                entity.Active = false;

                _context.Tournaments.Update(entity);
                await _context.SaveChangesAsync();
            }catch(Exception e){
                throw new Exception("Erro ao remover torneio.", e);
            }
           
        }

        public async Task<Tournament> Update(Tournament entity)
        {
            _context.Tournaments.Update(entity);
            
            await _context.SaveChangesAsync();
            return entity;
        } 
    }   
} 