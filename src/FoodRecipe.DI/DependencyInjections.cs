namespace FoodRecipe.DI
{

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    using FoodRecipe.Application.Services;
    using FoodRecipe.Application.Interfaces;
    using FoodRecipe.Infrastructure.Context;
    using FoodRecipe.Infrastructure.Repositories;
    using FoodRecipe.Domain;

    public static class DependencyInjections
    {

        public static IServiceCollection AddServices(this IServiceCollection service) =>
         service.AddTransient<IRecipeService, RecipeService>();

         public static IServiceCollection AddRepository(this IServiceCollection service) =>
         
         service.AddScoped<IRepository<FoodRecipeModel>, RecipeRepository>()
         .AddDbContext<FoodRecipeContext>(context => context.UseInMemoryDatabase(databaseName: "FoodRecipeDatabase"));
    }
}

