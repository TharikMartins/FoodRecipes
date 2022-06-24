namespace FoodRecipe.Domain
{
    public record FoodRecipeModel(int Id, string? Name, string? Instructions, ICollection<IngredientModel>? Ingredients)
    {
        public FoodRecipeModel() : this(default, default, default, default) { }
    }
}