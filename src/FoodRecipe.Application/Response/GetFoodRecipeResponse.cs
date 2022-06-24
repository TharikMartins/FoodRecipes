namespace FoodRecipe.Application.Response
{
    public record GetFoodRecipeResponse(int Id, string? Name, string? Instructions, IEnumerable<GetIngredientDTO>? Ingredients);
}