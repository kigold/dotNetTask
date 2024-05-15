using Microsoft.EntityFrameworkCore;
using ProgramsAPI.Data.Models;

namespace ProgramsAPI.Data
{
    public class ProgramDbContext : DbContext
    {
        public ProgramDbContext(DbContextOptions<ProgramDbContext> options) : base(options) { }

        public DbSet<ProgramInformation> ProgramInformation { get; set; }
        public DbSet<ProgramData> ProgramData { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultContainer("ProgramDB");

            builder.Entity<ProgramInformation>()
                .ToContainer(nameof(ProgramInformation))
                .HasPartitionKey(c => c.Id)
                .HasNoDiscriminator();

            builder.Entity<ProgramData>()
                .ToContainer(nameof(ProgramData))
                .HasPartitionKey(c => c.ProgramId)
                .HasNoDiscriminator();
        }
    }
}
