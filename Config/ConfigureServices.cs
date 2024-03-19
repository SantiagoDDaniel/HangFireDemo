using Microsoft.Extensions.DependencyInjection;

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
            op.UseMemoryStorage();
        });
        services.AddHangfireServer();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseHangfireDashboard();
    }
}