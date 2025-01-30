using _01.Core.Entities;
using Firebase.Database;
using Firebase.Database.Query;
using System.Text.Json;


namespace _02.Data.FirebaseRepository{
  public class TournamentRepository : ITournamentRepository 
{
    private readonly FirebaseClient _firebaseClient;
    private readonly string _childName;

    public TournamentRepository(string databaseUrl, string childName, string apiKey)
    {
        _firebaseClient = new FirebaseClient(databaseUrl, 
            new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(apiKey) });
        _childName = childName;
    }

    public Task AddTournament(Tournament tournament){
        return _firebaseClient.Child(_childName).PostAsync(JsonSerializer.Serialize(tournament));
    } 
}
  
}
