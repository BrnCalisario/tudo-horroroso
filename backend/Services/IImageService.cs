using TudoHorroroso.Model;

namespace TudoHorroroso.Services;

public interface IImageService
{
    Task<ImageDatum> GetImageBytes(IFormFile file);
}