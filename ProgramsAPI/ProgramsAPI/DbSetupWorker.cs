using ProgramsAPI.Data;

namespace ProgramsAPI
{
    public class DbSetupWorker : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DbSetupWorker(IServiceProvider serviceProvider)
           => _serviceProvider = serviceProvider;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ProgramDbContext>();
            await context.Database.EnsureCreatedAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}