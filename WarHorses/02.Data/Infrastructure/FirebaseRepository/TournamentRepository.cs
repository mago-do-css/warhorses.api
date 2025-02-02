using _01.Core.Entities;
using Firebase.Database;
using Firebase.Database.Query;
using Google.Cloud.Firestore;
using System.Text.Json; 

namespace _02.Data.FirebaseRepository
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly FirestoreDb _firestoreDb;

        public TournamentRepository(FirestoreDb firestoreDb)
        {
            _firestoreDb = firestoreDb;
        }

        public async Task<Tournament> AddTournament(Tournament tournament)
        { 
          var firebaseDto = tournament.ToFirebaseDTO();
           var result = await AddAsync(firebaseDto);
           return result.ConvertTo<Tournament>();
        }

        private string GetChildName<T>(T entity) { return typeof(T).Name; }

        private async Task<DocumentSnapshot> AddAsync<T>(T entity)
        {
            var childName = GetChildName(entity);
            var collection = _firestoreDb.Collection(childName);
            var result = await collection.AddAsync(entity);
            return await result.GetSnapshotAsync();
        }
    }
}