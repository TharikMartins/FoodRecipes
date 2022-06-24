namespace FoodRecipe.Application.Request
{
    public record UpdateFoodRecipeRequest(int Id, string? Name, string? Instructions, List<UpdateIngredientRequest>? Ingredients);
}