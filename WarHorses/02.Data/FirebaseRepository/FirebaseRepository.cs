using Firebase.Database;
using Firebase.Database.Query;
using System.Text.Json;

namespace _02.Data.FirebaseRepository{
  public class FirebaseRepository<T> : IRepository<T> where T : class
{
    private readonly FirebaseClient _firebaseClient;
    private readonly string _childName;

    public FirebaseRepository(string databaseUrl, string childName, string apiKey)
    {
        _firebaseClient = new FirebaseClient(databaseUrl, 
            new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(apiKey) });
        _childName = childName;
    }

    public async Task<T> GetByIdAsync(string id)
    {
        var result = await _firebaseClient.Child(_childName).Child(id).OnceSingleAsync<T>();
        return result;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var result = await _firebaseClient.Child(_childName).OnceAsync<T>();
        return result.Select(r => r.Object).ToList();
    }

    public async Task AddAsync(T entity)
    {
        await _firebaseClient.Child(_childName).PostAsync(JsonSerializer.Serialize(entity));
    }

    public async Task UpdateAsync(T entity)
    {
        var properties = entity.GetType().GetProperties();
        var idProp = properties.FirstOrDefault(p => p.Name == "Id");
        if (idProp == null) throw new Exception("Entidade não possui o campo 'Id'.");

        var id = idProp.GetValue(entity)?.ToString();
        if (string.IsNullOrEmpty(id)) throw new Exception("Id inválido.");

        await _firebaseClient.Child(_childName).Child(id).PutAsync(JsonSerializer.Serialize(entity));
    }

    public async Task DeleteAsync(string id)
    {
        await _firebaseClient.Child(_childName).Child(id).DeleteAsync();
    }
}
  
}
