using Microsoft.EntityFrameworkCore;
using shoptrack_be.Models;
using shoptrack_be.Repositories;

namespace shoptrack_be;
public class Startup
{

    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add DbContext
        services.AddDbContext<ShopTrackDbContext>(options =>
            options.UseNpgsql("Name=ConnectionStrings:DefaultConnection"));

        // Add repositories
        services.AddScoped<DiscountRepository>();
        services.AddScoped<PurchaseRepository>();
        services.AddScoped<ProductRepository>();
        services.AddScoped<UserRepository>();
        services.AddScoped<IUserService, UserRepository>();
        services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        services.AddScoped<StatisticRepository>();
        services.AddScoped<StoreRepository>();

        // Add other repositories similarly

        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();
        app.UseMiddleware<JwtMiddleware>();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
