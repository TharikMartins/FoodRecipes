namespace FoodRecipe.Application.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T?> Get(int id);
        Task<bool> Insert(T model);
        Task<bool> Update(T model);
        Task<bool> Delete(int id);
    }
}