using Microsoft.Extensions.DependencyInjection;
using Hangfire;
using Hangfire.Server;
using Hangfire.Console;
using Hangfire.MemoryStorage;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHangfire(config =>
        {
            config.UseMemoryStorage();
        });
        services.AddHangfireServer();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
    {
        app.UseHangfireDashboard();
        
        BackgroundJob.Enqueue(() => JobTeste());
    }

    public async Task JobTeste()
    {
        await Task.Run(() =>
        {
            Console.WriteLine("Meu primeiro job!");
        });
    }
}