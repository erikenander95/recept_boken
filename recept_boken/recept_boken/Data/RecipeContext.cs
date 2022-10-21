using Microsoft.EntityFrameworkCore;
using recept_boken.Models;

namespace recept_boken.Data
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options)
            : base(options)
        {
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
    }
}
