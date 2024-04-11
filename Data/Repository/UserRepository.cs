using KubernetesDeployment.Entities;
using Microsoft.EntityFrameworkCore;

namespace KubernetesDeployment.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentOutOfRangeException(nameof(context));
        }
        public async Task<Users?> GetUserAsync(Guid userId)
        {
            //returns only user detail
            return await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Users>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users> Login(string email, string password)
        {
            var user = await _context.Users.Where(c => c.Email == email).FirstOrDefaultAsync();
            if (user != null)
            {
                if (user.Email.Equals(email) && user.Password.Equals(password))
                {
                    return (user);
                }
            }
            return null;
        }
    }
}
