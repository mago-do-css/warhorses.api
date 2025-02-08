using Google.Cloud.Firestore;
using _01.Core.Entities;

namespace _02.Data.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> Create(T entity); 
        Task<T> Update(T entity);
        Task<T> GetById(Guid id);
        Task<ICollection<T>> GetAll();
        Task Remove(Guid id);
    }
}
