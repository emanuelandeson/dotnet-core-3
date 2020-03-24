using Flunt.Notifications;
using GolLabs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GolLabs.Infra.Contexts
{
    public class GLContext : DbContext
    {
        public GLContext(DbContextOptions<GLContext> options) :
           base(options)
        {
             
        }

        public DbSet<User> Users{ get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            var options = new DbContextOptionsBuilder()
             .EnableSensitiveDataLogging()
             .Options;
        }
}
}