namespace FoodRecipe.Infrastructure.Repositories
{
    using FoodRecipe.Infrastructure.Context;
    using FoodRecipe.Application.Interfaces;
    using FoodRecipe.Domain;
    using Microsoft.EntityFrameworkCore;

    public class RecipeRepository : IRepository<FoodRecipeModel>
    {
        private readonly FoodRecipeContext _context;
        public RecipeRepository(FoodRecipeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FoodRecipeModel>> Get()
        {
            return await _context.FoodRecipe
                .Include(x => x.Ingredients)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<FoodRecipeModel?> Get(int id)
        {
            FoodRecipeModel? foodRecipeModel;

            foodRecipeModel = await _context.FoodRecipe
                             .Include(x => x.Ingredients)
                             .AsNoTracking()
                             .FirstOrDefaultAsync(x => x.Id == id);

            return foodRecipeModel;
        }

        public async Task<bool> Insert(FoodRecipeModel model)
        {

            await _context.FoodRecipe
                       .AddAsync(model);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(FoodRecipeModel model)
        {

            if (await this.Get(model.Id) is null) return false;

            _context.FoodRecipe
                  .Update(model);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {

            FoodRecipeModel? recipe = await this.Get(id);

            if (recipe is null)
                return false;

            _context.FoodRecipe.Remove(recipe);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}