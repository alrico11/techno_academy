using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TechnoAcademyApi.DataSeeder;

namespace TechnoAcademyApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                // Memanggil metode SeedData dari DataSeeder
                //DataSeeders.SeedData(serviceProvider);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
