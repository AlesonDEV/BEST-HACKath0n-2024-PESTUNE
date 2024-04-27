
using AutoMapper;
using BloodFlow.BuisnessLayer.Interfaces;
using BloodFlow.BuisnessLayer.Services;
using BloodFlow.DataLayer.Data;
using BloodFlow.DataLayer.Interfaces;
using BloodFlow.Infrastructure.Mapper;
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

            builder.Services.AddDbContext<BloodFlowDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("BloodFlow")));

            builder.Services.AddScoped<IMapper>(sp =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<AutomapperProfile>();
                });
                return config.CreateMapper();
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IDonorService, DonorService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
