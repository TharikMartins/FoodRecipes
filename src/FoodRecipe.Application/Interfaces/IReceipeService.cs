using FoodRecipe.Domain;

namespace FoodRecipe.Application.Interfaces
{
    public interface IRecipeService
    {
        Task<IEnumerable<FoodRecipeModel>> Get();
        Task<FoodRecipeModel?> Get(int id);
        Task<bool> Insert(FoodRecipeModel model);
        Task<bool> Update(FoodRecipeModel model);
        Task<bool> Delete(int id);
    }
}