namespace FoodRecipe.Application.Request
{
    public record UpdateIngredientRequest(int? Id, string? Name, int Quantity);
}