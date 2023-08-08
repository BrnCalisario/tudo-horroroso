using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TudoHorroroso.Model;


public class Recipe
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }

    public ICollection<Ingredient> Ingredients = new List<Ingredient>();
    public ICollection<Step> Steps = new List<Step>();

    public void AddIngredient(Ingredient ingredient)
        => this.Ingredients.Add(ingredient);
    public void RemoveIngredient(Ingredient ingredient)
        => this.Ingredients.Remove(ingredient);
    public void AddStep(Step step)
        => this.Steps.Add(step);
    public void RemoveStep(Step step)
        => this.Steps.Remove(step);
}