using Microsoft.EntityFrameworkCore;
using ProgramsAPI.Data.Models;

namespace ProgramsAPI.Data
{
    public class ProgramDbContext : DbContext
    {
        public ProgramDbContext(DbContextOptions<ProgramDbContext> options) : base(options) { }

        public DbSet<ProgramQuestion> ProgramQuestions { get; set; }
        public DbSet<ProgramResponse> ProgramResponse { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultContainer("ProgramDB");

            builder.Entity<ProgramQuestion>()
                .ToContainer(nameof(ProgramQuestion))
                .HasPartitionKey(c => c.Id)
                .HasNoDiscriminator();

            builder.Entity<ProgramResponse>()
                .ToContainer(nameof(ProgramResponse))
                .HasPartitionKey(c => c.ProgramId)
                .HasNoDiscriminator();
        }
    }
}
