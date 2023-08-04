namespace TudoHorroroso.Model;


public class Recipe
{
    public string Name { get; set; }
    public string Author { get; set; }
    public List<Ingredient> Ingredients = new List<Ingredient>();
    public List<string> Steps = new List<string>();


    public void AddIngredient(Ingredient ingredient)
        => this.Ingredients.Add(ingredient);

    public void RemoveIngredient(Ingredient ingredient)
        => this.Ingredients.Remove(ingredient);

}