using Google.Cloud.Firestore;

namespace _02.Data.Infrastructure.FirebaseDto
{
    [FirestoreData]
    public class TournamentFirestore
    {
        [FirestoreProperty]
        public string Id { get; set; }
        
        [FirestoreProperty]
        public string? Description { get; set; }
        
        [FirestoreProperty]
        public DateTime Date { get; set; }
        
        [FirestoreProperty]
        public int Type { get; set; }
    }
}
