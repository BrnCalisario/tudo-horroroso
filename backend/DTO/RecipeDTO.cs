using TudoHorroroso.Model;

namespace TudoHorroroso.DTO
{
    public class RecipeDTO
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public byte[] Photo { get; set; }


        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Step> Steps { get; set; }
    }
}
