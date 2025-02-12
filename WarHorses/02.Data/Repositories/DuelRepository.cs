using _01.Core.Entities;
using _01.Core.Enums;
using _02.Data.Interfaces; 
using Microsoft.EntityFrameworkCore;

namespace _02.Data.Repositories
{
    public class DuelRepository : IDuelRepository
    {
        private readonly  WarhosesDbContext _context;
        public DuelRepository(WarhosesDbContext context)
        { 
            _context = context;
        } 
        
        public async Task<Duel> GetById(Guid id)
        {
            var entity = await _context.Duels.FirstOrDefaultAsync(d=>d.Id == id); 

            if(entity == null) throw new Exception("Duelo nao encontrado!");

            return entity;
        }  

        public async Task<Duel> Create(Duel duel){
            var result =  await _context.Duels.AddAsync(duel);
            await _context.SaveChangesAsync();
            return result.Entity;
        } 
        
        public async Task<ICollection<Duel>> GetAll()
        {
            return await _context.Duels.ToListAsync();
        }

         public async Task<ICollection<Duel>> GetAllDuelsActive()
        {
            return await _context.Duels.Where(d => d.Status == StatusDuelEnum.NotStarted || d.Status == StatusDuelEnum.Started).ToListAsync();
        }

       // TODO: DECLARAR O VENCEDOR
         public async Task<Duel> FinishDuel(Duel duel)
        {
            try{ 
                var entity = await _context.Duels.FirstOrDefaultAsync(); 

                if(entity == null) throw new Exception("Duelo nao encontrado!");

                entity.Status = StatusDuelEnum.Finished;

                _context.Duels.Update(entity);
                await _context.SaveChangesAsync();
                
                return entity;
            }catch(Exception e){
                throw new Exception("Erro ao cancelar duelo.", e);
            }
           
        } 

        public async Task Remove(Guid id)
        {
            try{ 
                var entity = await _context.Duels.FirstOrDefaultAsync(t=>t.Id == id); 

                if(entity == null) throw new Exception("Duelo nao encontrado!");

                entity.Status = StatusDuelEnum.Canceled;

                _context.Duels.Update(entity);
                await _context.SaveChangesAsync();
            }catch(Exception e){
                throw new Exception("Erro ao cancelar duelo.", e);
            }
           
        }

        public async Task<Duel> Update(Duel entity)
        {
            _context.Duels.Update(entity);
            
            await _context.SaveChangesAsync();
            return entity;
        } 
    }   
} 