using Google.Cloud.Firestore;
using _01.Core.Entities;

namespace _02.Data.FirebaseRepository
{
    public interface ITournamentRepository
    {
        Task AddTournament(Tournament tournament);
        //Task<DocumentSnapshot> GetTournament(string collectionName, string documentId);
       // Task DeleteTournament(string collectionName, string documentId);
    
    }
}
