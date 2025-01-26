using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;

namespace _02.Data.FirebaseRepository
{
    public class TesteRepo : ITesteRepoRepository
    {
        private readonly FirestoreDb _firestoreDb; 


        public TesteRepo(FirestoreDb firestoreDb)
        {
            _firestoreDb = firestoreDb; 
        }

        // Método para salvar um dado no Firebase Firestore
        public async Task AddDocumentAsync(string collectionName, string documentId, object data)
        {
            var collection = _firestoreDb.Collection(collectionName);
            await collection.Document(documentId).SetAsync(data);
        }

        // Método para buscar um documento
        public async Task<DocumentSnapshot> GetDocumentAsync(string collectionName, string documentId)
        {
         var teste = await _firestoreDb.Collection(collectionName).Document(documentId).GetSnapshotAsync();
         return teste;
        }

        // Método para deletar um documento
        public async Task DeleteDocumentAsync(string collectionName, string documentId)
        {
            var collection = _firestoreDb.Collection(collectionName);
            await collection.Document(documentId).DeleteAsync();
        }
    }
}
