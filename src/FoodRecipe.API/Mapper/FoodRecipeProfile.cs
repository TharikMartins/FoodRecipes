namespace FoodRecipe.API
{
    using AutoMapper;
    using FoodRecipe.Application.Request;
    using FoodRecipe.Application.Response;
    using FoodRecipe.Domain;

    public class FoodRecipeProfile : Profile
    {
        public FoodRecipeProfile()
        {
            CreateMap<FoodRecipeModel, GetFoodRecipeResponse>()
            .ForMember(x => x.Ingredients, opt => opt.MapFrom(src => src.Ingredients != null
            ? src.Ingredients.ToList() : null));
            CreateMap<IngredientModel, GetIngredientDTO>();

            CreateMap<InsertFoodRecipeRequest, FoodRecipeModel>();
            CreateMap<InsertIngredientRequest, IngredientModel>();

            CreateMap<UpdateFoodRecipeRequest, FoodRecipeModel>()
            .ForMember(x => x.Ingredients, opt => opt.MapFrom(src => src.Ingredients != null
            ? src.Ingredients.ToList() : null));
            CreateMap<UpdateIngredientRequest, IngredientModel>();
        }
    }
}