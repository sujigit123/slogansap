using Microsoft.EntityFrameworkCore;
using SloganSAP.API.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SloganSAP.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Register ApplicationDbContext (use DefaultConnection from appsettings.json)
            builder.Services.AddDbContext<SloganSAPDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SloganSAPConnection")));

            var app = builder.Build();

            // Apply any pending migrations and create the database (and related tables / relationships)
            // This will ensure the schema created by your migrations exists when the app starts.
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SloganSAPDbContext>();
                    // Will create the database and apply all pending migrations
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating or initializing the database.");
                    throw;
                }
            }

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
