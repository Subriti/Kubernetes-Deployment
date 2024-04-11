using KubernetesDeployment.Entities;

namespace KubernetesDeployment.Data.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> GetUsersAsync();
        Task<Users?> GetUserAsync(Guid userId);
        Task<Users> Login(string email, string password);
    }
}
