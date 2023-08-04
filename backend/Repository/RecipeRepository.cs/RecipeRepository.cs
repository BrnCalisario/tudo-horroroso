using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TudoHorroroso.Model;

namespace TudoHorroroso.Repositories;

public class RecipeRepository : IRepository<Recipe>
{

    private readonly IMongoCollection<Recipe> _recipeCollection;

    public RecipeRepository(IOptions<RecipeDatabaseSettings> settings) // Setar configs no 
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);

        var mogoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

        _recipeCollection = mogoDatabase.GetCollection<Recipe>(settings.Value.RecipeCollectionName);
    }

    public async Task Add(Recipe obj)
       => await _recipeCollection.InsertOneAsync(obj);
    
    public async Task Delete(Recipe obj)
        => await _recipeCollection.DeleteOneAsync(recipe=> recipe.Id == obj.Id);

    public async Task Update(Recipe obj)
        => await _recipeCollection.ReplaceOneAsync(recipe => recipe.Id == obj.Id, obj);
    
    public async Task<List<Recipe>> Filter(Expression<Func<Recipe, bool>> exp)
    {
        var data = await _recipeCollection.Find(exp).ToListAsync();
        return data;
    }
}