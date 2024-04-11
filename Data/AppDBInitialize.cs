using KubernetesDeployment.Entities;
using System.Globalization;

namespace KubernetesDeployment.Data
{
    public static class AppDBInitialize
    {
        public static async Task SeedConstantsAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                // Ensure the database is created
                await context.Database.EnsureCreatedAsync();

                // Check if users already exist
                if (!context.Users.Any())
                {
                    // Seed Users
                    context.Users.AddRange(
                        new Users { Email = "admin@gmail.com", Password="admin123", Username = "admin", Fullname = "Teller Person", Address = "Kathmandu", PhoneNumber = "9826274833", DateOfBirth = DateTime.SpecifyKind(DateTime.ParseExact("2002-08-20T11:13:25.342Z", "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture), DateTimeKind.Utc) }
                        // Add more users if needed
                    );

                    // Save changes
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
