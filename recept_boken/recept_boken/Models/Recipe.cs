namespace recept_boken.Models
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public List<Ingredient> ingredients { get; set; }
        public string instructions { get; set; }
    }
}
