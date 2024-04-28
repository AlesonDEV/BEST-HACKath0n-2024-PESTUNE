
using AutoMapper;
using BloodFlow.BuisnessLayer.Interfaces;
using BloodFlow.BuisnessLayer.Services;
using BloodFlow.DataLayer.Data;
using BloodFlow.DataLayer.Interfaces;
using BloodFlow.Infrastructure.Mapper;
using BloodFlow.PresentaionLayer.Middleware;
using Microsoft.EntityFrameworkCore;

namespace BloodFlow
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // DbContext
            builder.Services.AddDbContext<BloodFlowDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("BloodFlow")));

            // Automapper
            builder.Services.AddScoped<IMapper>(sp =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<AutomapperProfile>();
                });
                return config.CreateMapper();
            });

            // Di - containers
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IDonorService, DonorService>();
            builder.Services.AddScoped<ISessionService, SessionService>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<IBloodTypeServices, BloodTypeServices>();
            builder.Services.AddScoped<IImportanceService, ImportanceService>();
            builder.Services.AddScoped<IDonorCenterService, DonorCenterService>();
            builder.Services.AddScoped<ILoginService, LoginService>();

            // Cors
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("policy", policyBuilder =>
                {
                    policyBuilder.WithOrigins
                        ("https://bloodflowpresentaionlayer20240428063721.azurewebsites.net");
                    policyBuilder.AllowAnyHeader();
                    policyBuilder.AllowAnyMethod();
                    policyBuilder.AllowAnyOrigin();
                });
            });

            var app = builder.Build();

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Dispatch API V1");
                opt.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.MapControllers();

            app.UseCors("policy");

            SeedDataMiddleware.EnsurePopulated(app);

            app.Run();
        }
    }
}
