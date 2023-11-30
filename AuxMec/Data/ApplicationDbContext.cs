using Microsoft.EntityFrameworkCore;
using OnlineMechanic.Entities;

namespace OnlineMechanic.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<MechanicalWorkshop> MechanicalWorkshops { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<WorkShopMechanicalMechanic> WorkShopMechanicalMechanics { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Assistance> Assistances { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
