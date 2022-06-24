namespace FoodRecipe.Domain
{
    public record IngredientModel(int Id, string? Name, int Quantity)
    {
        public IngredientModel() : this(default, default, default) { }
    
    }
}