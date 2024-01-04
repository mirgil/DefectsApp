
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;

namespace DefectsApp
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddOData(options => options.SetMaxTop(100));
            builder.Services.AddDbContext<DefectsContext>();

            var app = builder.Build();


            
            app.MapControllers();
            // Migrate latest database changes during startup
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<DefectsContext>();

                // Migrate the DB if required
                dbContext.Database.Migrate();
            }
            app.Run();
        }
    }
}
