using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserApi.Models;
using RoomApi.Models; // Added to import RoomMongoDBSettings

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration; // Initialize Configuration
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Configure UserMongoDBSettings
        services.Configure<UserMongoDBSettings>(
            Configuration.GetSection(nameof(UserMongoDBSettings)));

        // Configure RoomMongoDBSettings
        services.Configure<RoomMongoDBSettings>(
            Configuration.GetSection(nameof(RoomMongoDBSettings)));

        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IUserService, UserService>();
        // You may need to add similar repository and service registrations for Room
         services.AddSingleton<IRoomRepository, RoomRepository>();
         services.AddSingleton<IRoomService, RoomService>();

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
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers(); // Map controller routes
        });
    }
}
