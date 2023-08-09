using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TudoHorroroso.Model;
using TudoHorroroso.Repositories;

namespace TudoHorroroso.Services;

public class ImageRecipeService : IImageService
{

    private readonly IMongoCollection<Recipe> _recipeCollection;

    public ImageRecipeService(IOptions<RecipeDatabaseSettings> settings) // Setar configs no 
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);

        var mogoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

        _recipeCollection = mogoDatabase.GetCollection<Recipe>(settings.Value.RecipeCollectionName);
    }
    public async Task<byte[]> GetImageBytes(IFormFile file)
    {
        using MemoryStream ms = new MemoryStream();

        await file.CopyToAsync(ms);
        var data = ms.GetBuffer();

        return data;
    }
}