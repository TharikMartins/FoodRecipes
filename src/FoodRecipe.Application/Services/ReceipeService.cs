using FoodRecipe.Application.Interfaces;
using FoodRecipe.Domain;

namespace FoodRecipe.Application.Services
{
    public class RecipeService : IRecipeService
    {

        private readonly IRepository<FoodRecipeModel> _repository;

        public RecipeService(IRepository<FoodRecipeModel> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FoodRecipeModel>> Get()
        {
            return await _repository.Get();
        }

         public async Task<FoodRecipeModel?> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<bool> Insert(FoodRecipeModel model)
        {   
            return await _repository.Insert(model);
        }

        public async Task<bool> Update(FoodRecipeModel model)
        {   
            return await _repository.Update(model);
        }

        public async Task<bool> Delete(int id)
        {   
            return await _repository.Delete(id);
        }
    }
}