using Firebase.Storage;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System.Threading.Tasks;

namespace sigmaback.Infra.Data.Services
{
    public class FirebaseStorageService
    {
        private readonly FirebaseStorage _firebaseStorage;

        public FirebaseStorageService()
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("path/to/your-service-account-file.json")
            });

            _firebaseStorage = new FirebaseStorage("your-storage-bucket");
        }

        public async Task<string> UploadFileAsync(Stream fileStream, string path)
        {
            var uploadTask = _firebaseStorage
                .Child(path)
                .PutAsync(fileStream);

            // Aguardar o término do upload
            var uploadResult = await uploadTask;

            // Obter a URL de download do arquivo
            return uploadResult;
        }

        public async Task DeleteFileAsync(string path)
        {
            await _firebaseStorage
                .Child(path)
                .DeleteAsync();
        }
    }
}
