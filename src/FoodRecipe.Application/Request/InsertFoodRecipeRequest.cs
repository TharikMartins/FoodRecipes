namespace FoodRecipe.Application.Request
{
    public record InsertFoodRecipeRequest(string? Name, string? Instructions, List<InsertIngredientRequest>? Ingredients);
}