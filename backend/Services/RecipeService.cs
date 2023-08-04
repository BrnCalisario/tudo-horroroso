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

        public byte[] GenerateHexId()
        {
            Random rand = new Random();
            int len;
            byte[] bytesValue;

            while (true)
            {
                len = rand.Next(24);
                bytesValue = new byte[len];
                rand.NextBytes(bytesValue);

                bool exists = _recipeCollection.Count(recipe => recipe.Id == bytesValue) == 0 ? false : true;

                if (!exists)
                    return bytesValue;
            }
        }
    }
}
