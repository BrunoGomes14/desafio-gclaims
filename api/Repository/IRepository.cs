using api.Domain.Entity;

namespace api.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<CharacterResumed>> GetAll(CharacterFilter filter);
        Task AddFav(int id);
        Task DeleteFav(int id);
        Task Delete(int id);
    }
}