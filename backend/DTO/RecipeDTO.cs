using TudoHorroroso.Model;

namespace TudoHorroroso.DTO
{
    public class RecipeDTO
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public List<Ingredient> Ingredients = new List<Ingredient>();
        public List<string> Steps = new List<string>();
    }
}
