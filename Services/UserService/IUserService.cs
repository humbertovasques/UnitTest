using Domain;

namespace Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
    }
}