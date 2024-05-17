using System.IO;
using System.Threading.Tasks;

namespace sigmaBack.Domain.Interfaces
{
    public interface IImageRepository
    {
        Task<string> UploadImageAsync(Stream fileStream, string fileName);
        Task DeleteImageAsync(string imagePath);
    }
}

