using sigmaback.Infra.Data.Services;
using sigmaBack.Domain.Interfaces;
using sigmaBack.Domain.Entities;
using System.IO;
using System.Threading.Tasks;

namespace sigmaBack.Application.Services
{
    public class ImageService
    {
        private readonly FirebaseStorageService _firebaseStorageService;
        private readonly IImageRepository _imageRepository;

        public ImageService(FirebaseStorageService firebaseStorageService, IImageRepository imageRepository)
        {
            _firebaseStorageService = firebaseStorageService;
            _imageRepository = imageRepository;
        }

        public async Task<string> UploadProductImageAsync(int productId, Stream fileStream, string fileName)
        {
            var path = $"Produtos/{productId}/{fileName}";
            return await _firebaseStorageService.UploadFileAsync(fileStream, path);
        }

        public async Task<string> UploadReviewVideoAsync(int reviewId, Stream fileStream, string fileName)
        {
            var path = $"Avaliacoes/{reviewId}/{fileName}";
            return await _firebaseStorageService.UploadFileAsync(fileStream, path);
        }

        public async Task<string> UploadAdImageAsync(int adId, Stream fileStream, string fileName)
        {
            var path = $"Anuncios/{adId}/{fileName}";
            return await _firebaseStorageService.UploadFileAsync(fileStream, path);
        }

        public async Task<string> UploadGameImageAsync(int gameId, Stream fileStream, string fileName)
        {
            var path = $"Jogos/{gameId}/{fileName}";
            return await _firebaseStorageService.UploadFileAsync(fileStream, path);
        }
    }

}

