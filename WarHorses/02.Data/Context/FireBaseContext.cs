using Firebase.Database;
using System.Threading.Tasks;

namespace _02.Data.FirebaseRepository
{
    public class FirebaseContext
    {
        private readonly FirebaseClient _firebaseClient;

        public FirebaseContext(string databaseUrl, string apiKey)
        {
            _firebaseClient = new FirebaseClient(databaseUrl, new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(apiKey)
            });
        }

        public FirebaseClient GetClient() => _firebaseClient;
    }
}
