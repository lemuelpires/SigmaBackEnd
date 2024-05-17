// API/Controllers/ImageController.cs
using Microsoft.AspNetCore.Mvc;
using sigmaBack.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace sigmaBack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly ImageService _imageService;

        public ImageController(ImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("uploadProductImage/{productId}")]
        public async Task<IActionResult> UploadProductImage(int productId, IFormFile file)
        {
            using var stream = file.OpenReadStream();
            var url = await _imageService.UploadProductImageAsync(productId, stream, file.FileName);
            return Ok(new { Url = url });
        }

        [HttpPost("uploadReviewVideo/{reviewId}")]
        public async Task<IActionResult> UploadReviewVideo(int reviewId, IFormFile file)
        {
            using var stream = file.OpenReadStream();
            var url = await _imageService.UploadReviewVideoAsync(reviewId, stream, file.FileName);
            return Ok(new { Url = url });
        }

        [HttpPost("uploadAdImage/{adId}")]
        public async Task<IActionResult> UploadAdImage(int adId, IFormFile file)
        {
            using var stream = file.OpenReadStream();
            var url = await _imageService.UploadAdImageAsync(adId, stream, file.FileName);
            return Ok(new { Url = url });
        }

        [HttpPost("uploadGameImage/{gameId}")]
        public async Task<IActionResult> UploadGameImage(int gameId, IFormFile file)
        {
            using var stream = file.OpenReadStream();
            var url = await _imageService.UploadGameImageAsync(gameId, stream, file.FileName);
            return Ok(new { Url = url });
        }
    }
}

