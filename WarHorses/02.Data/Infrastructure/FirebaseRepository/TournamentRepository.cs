using _01.Core.Entities;
using Firebase.Database;
using Firebase.Database.Query;
using Google.Cloud.Firestore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json; 

namespace _02.Data.FirebaseRepository
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly FirestoreDb _firestoreDb;
        private readonly WarhosesDbContext _context;
                           

        public TournamentRepository(FirestoreDb firestoreDb, WarhosesDbContext context)
        {
            _firestoreDb = firestoreDb;
            _context = context;
        }

          public async Task<Tournament> AddTournament(Tournament tournament)
        { 
           var result = _context.Tournaments.Add(tournament);
           await _context.SaveChangesAsync();
           return result.Entity;
        }

        //   public async Task<Tournament> AddTournament(Tournament tournament)
        // { 
        //     var childName = GetChildName(tournament);
        //     var firebaseDto = tournament.ToFirebaseDTO();
        //     var result = await AddAsync(firebaseDto, childName);
        //     return result.ConvertTo<Tournament>();
        // }

        private string GetChildName<T>(T entity) { return typeof(T).Name; }

        private async Task<DocumentSnapshot> AddAsync<T>(T entity, string childName)
        {
            var collection = _firestoreDb.Collection(childName);
            var result = await collection.AddAsync(entity);
            return await result.GetSnapshotAsync();
        }
    }
}