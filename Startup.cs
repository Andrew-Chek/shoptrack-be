using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using shoptrack_be.Models;
using shoptrack_be.Repositories;

namespace shoptrack_be;
public class Startup
{
    public Startup()
    {
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

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
