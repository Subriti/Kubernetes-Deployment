using KubernetesDeployment.Entities;
using Microsoft.EntityFrameworkCore;

namespace KubernetesDeployment.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Defining Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //Define Databases
        public DbSet<Users> Users { get; set; }
    }
}
