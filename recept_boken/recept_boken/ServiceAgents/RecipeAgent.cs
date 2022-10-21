using Microsoft.EntityFrameworkCore;
using recept_boken.Data;
using recept_boken.Models;

namespace recept_boken.ServiceAgents
{
    public class RecipeAgent
    {
        public RecipeContext _RecipeContext { get; }
        public RecipeAgent(RecipeContext recipeContext)
        {
            _RecipeContext = recipeContext;
        }

        public async Task<List<Recipe>> GetAllRecipes()
        {
            return await _RecipeContext.Recipes.ToListAsync();
        }

        public async Task<Recipe> GetRecipe(Guid recipeId)
        {
            return await _RecipeContext.Recipes.FirstOrDefaultAsync(x => x.Id == recipeId);
        }

        public async Task<Recipe> AddRecipe(string title, List<Ingredient> ingredients, string instructions)
        {
            if (await _RecipeContext.Recipes.FirstOrDefaultAsync(x => x.title == title) != null)
            {
                return null;
            }
            Recipe recipe = new Recipe
            {
                title = title,
                ingredients = ingredients,
                instructions = instructions,
            };
            await _RecipeContext.Recipes.AddAsync(recipe);
            await _RecipeContext.SaveChangesAsync();
            return recipe;
        }

        public async Task<string> UpdateRecipeTitle(Guid Id, string title)
        {
            Recipe recipe = await _RecipeContext.Recipes.FirstOrDefaultAsync(x => x.Id == Id);
            recipe.title = title;
            await _RecipeContext.SaveChangesAsync();
            return "updated";
        }
        public async Task<string> UpdateRecipeInstructions(Guid Id, string instructions)
        {
            Recipe recipe = await _RecipeContext.Recipes.FirstOrDefaultAsync(x => x.Id == Id);
            recipe.instructions = instructions;
            await _RecipeContext.SaveChangesAsync();
            return "updated";
        }
        public async Task<string> UpdateRecipeIngrediants(Guid recipeId, Guid ingredientId, bool remove)
        {
            Recipe recipe = await _RecipeContext.Recipes.FirstOrDefaultAsync(x => x.Id == recipeId);
            Ingredient ingredient = await _RecipeContext.Ingredients.FirstOrDefaultAsync(x => x.Id == ingredientId);
            if (remove)
            {
                recipe.ingredients.Remove(ingredient);
            }
            else
            {
                recipe.ingredients.Add(ingredient);
            }
            await _RecipeContext.SaveChangesAsync();
            return "updated";
        }

        //RemoveRecipe

    }
}
