// http://www.entityframeworktutorial.net/efcore/configure-many-to-many-relationship-in-ef-core.aspx
// http://www.entityframeworktutorial.net/efcore/configure-one-to-many-relationship-using-fluent-api-in-ef-core.aspx

using FluentNHibernate.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Training.Models.Entities;

namespace Training.Models
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _config;

        public ApplicationDbContext(IConfiguration config, DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            _config = config;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ---------- Use concurrency tokens (xmin) ---------------
            // https://www.npgsql.org/efcore/misc.html
            // Optimistic Concurrency and Concurrency Tokens
            modelBuilder.HasPostgresExtension("hstore");
            modelBuilder.Entity<Entities.Training>().ForNpgsqlUseXminAsConcurrencyToken();
            modelBuilder.Entity<Entities.TrainingGroup>().ForNpgsqlUseXminAsConcurrencyToken();
            // modelBuilder.Entity<Entities.TrainingGroupTraining>().ForNpgsqlUseXminAsConcurrencyToken();
            // --------------------------------------------------------

            // TrainingGroupTraining
            //modelBuilder.Entity<TrainingGroupTraining>().HasKey(sc => new { sc.TrainingId, sc.TrainingGroupId });

            // below lines don't necessary. They are needed just if fields named not "TrainingId" and "TrainingGroupId" (http://www.entityframeworktutorial.net/efcore/configure-many-to-many-relationship-in-ef-core.aspx)
            // modelBuilder.Entity<TrainingGroupTraining>().HasOne<TrainingGroup>(tg => tg.TrainingGroup).WithMany(t => t.TrainingGroupTraining).HasForeignKey(tg1 => tg1.TrainingGroupId);
            // modelBuilder.Entity<TrainingGroupTraining>().HasOne<Training>(tg => tg.Training).WithMany(t => t.TrainingGroupTraining).HasForeignKey(tg1 => tg1.TrainingId);



        }

        public DbSet<Entities.Training> Training { get; set; }
        public DbSet<Entities.TrainingGroup> TrainingGroup { get; set; }
        // public DbSet<Entities.TrainingGroupTraining> TrainingGroupTraining { get; set; }
    }
}