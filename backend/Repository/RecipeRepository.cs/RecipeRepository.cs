using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TudoHorroroso.Model;

namespace TudoHorroroso.Repository;

public class RecipeRepository : IRepository<Recipe>
{

    private readonly IMongoCollection<Recipe> _bookCollection;

    public RecipeRepository(IOptions<BookStoreDatabaseSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);

        var mogoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

        _bookCollection = mogoDatabase.GetCollection<Recipe>(settings.Value.BookCollectionName);
    }

    public Task Add(Recipe obj)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Recipe obj)
    {
        throw new NotImplementedException();
    }

    public Task<List<Recipe>> Filter(Expression<Func<Recipe, bool>> exp)
    {
        throw new NotImplementedException();
    }

    public Task Update(Recipe obj)
    {
        throw new NotImplementedException();
    }
}

