using _01.Core.Entities;
using Firebase.Database;
using Firebase.Database.Query;
using System.Text.Json;
 
namespace _02.Data.FirebaseRepository{
  public class TournamentRepository
    {
    private readonly FirebaseClient _firebaseClient;

    public TournamentRepository(FirebaseContext firebaseContext)
    {
        _firebaseClient = firebaseContext.GetClient(); 
    }

    public async Task<Tournament> AddTournament(Tournament tournament){
        var childName = GetChildName(tournament);
        var teste = await _firebaseClient.Child(childName).PostAsync(JsonSerializer.Serialize(tournament));

        return JsonSerializer.Deserialize<Tournament>(teste.Object) ?? new Tournament();
    }  
    private string GetChildName<T>(T entity){return typeof(T).Name;}
    }
}