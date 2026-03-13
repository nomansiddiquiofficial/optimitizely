using Serilog;

namespace OptimizelyDemo;

public class Program
{
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(
                new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build())
            .CreateLogger();

        try
        {
            Log.Information("Starting web host");

            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog() // 🔹 Integrate Serilog with ASP.NET logging
            .ConfigureCmsDefaults() // 🔹 Required for Optimizely CMS
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}