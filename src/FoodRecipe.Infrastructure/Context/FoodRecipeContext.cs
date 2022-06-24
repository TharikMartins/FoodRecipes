using Microsoft.EntityFrameworkCore;
using FoodRecipe.Domain;

namespace FoodRecipe.Infrastructure.Context
{
    public class FoodRecipeContext : DbContext
    {
        public FoodRecipeContext(DbContextOptions<FoodRecipeContext> context) : base(context) { }
        public DbSet<FoodRecipeModel> FoodRecipe => Set<FoodRecipeModel>();
        public DbSet<IngredientModel> IngredientModels => Set<IngredientModel>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FoodRecipeModel>()
               .HasKey(m => m.Id);
            
            builder.Entity<IngredientModel>()
               .HasKey(m => m.Id);
        }
    }
}