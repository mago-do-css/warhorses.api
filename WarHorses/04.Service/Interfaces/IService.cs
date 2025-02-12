namespace _04.Service.Interfaces
{
    public interface IService<T>
    {
        Task<T> Create(T dto);
        Task<T> Update(T dto);
        Task Remove(Guid id);
        Task<ICollection<T>> GetAll();
        Task<T> GetById(Guid id); 
    }
} 