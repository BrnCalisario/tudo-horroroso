using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TudoHorroroso.Model;
using TudoHorroroso.Repositories;

namespace TudoHorroroso.Services
{
    public class RecipeService
    {
        private readonly IMongoCollection<Recipe> _recipeCollection;

        public RecipeService(IOptions<RecipeDatabaseSettings> settings) // Setar configs no 
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);

            var mogoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _recipeCollection = mogoDatabase.GetCollection<Recipe>(settings.Value.RecipeCollectionName);
        }

        public async Task<ActionResult<List<Recipe>>> GetAll()
            =>  await this._recipeCollection.Find(_ => true).ToListAsync();
       
    }
}
