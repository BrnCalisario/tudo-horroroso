using TudoHorroroso.Model;

namespace TudoHorroroso.Services;

public interface IImageService
{
    Task<byte[]> GetImageBytes(IFormFile file);
}