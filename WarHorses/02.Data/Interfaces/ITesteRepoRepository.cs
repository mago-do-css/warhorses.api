using Google.Cloud.Firestore;

namespace _02.Data.FirebaseRepository
{
    public interface ITesteRepoRepository
    {
        Task AddDocumentAsync(string collectionName, string documentId, object data);
        Task<DocumentSnapshot> GetDocumentAsync(string collectionName, string documentId);
        Task DeleteDocumentAsync(string collectionName, string documentId);
    
    }
}
