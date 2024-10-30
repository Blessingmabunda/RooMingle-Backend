using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerGen;
using UserApi.Models;
using RoomApi.Models;
using Microsoft.OpenApi.Models;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<UserMongoDBSettings>(
            Configuration.GetSection(nameof(UserMongoDBSettings)));

        services.Configure<RoomMongoDBSettings>(
            Configuration.GetSection(nameof(RoomMongoDBSettings)));

        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<IRoomRepository, RoomRepository>();
        services.AddSingleton<IRoomService, RoomService>();

        services.AddControllers();

        // Add Swagger services
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo 
            { 
                Title = "RooMingle API", 
                Version = "v1" 
            });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger(); // Use Swagger
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RooMingle API v1"));
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
            endpoints.MapControllers();
        });
    }
}