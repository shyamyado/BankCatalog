using CatalogEventBus;
using NLog.Extensions.Logging;
using OfferCatalog.API.Infrastructure;
using OfferCatalog.API.Infrastructure.Repository;
using OfferCatalog.API.Services;
using RabbitMQ.Client;

namespace OfferCatalog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IRabbitMQPersistantConnection>(sp =>
            {
                var factory = new ConnectionFactory { HostName = "localhost", UserName = "user01", Password = "123", Port = 5672, };
                return new RabbitMQPersistantConnection(factory);
            });

            builder.Services.AddDbContext<CatalogDBContext>();
            builder.Services.AddScoped<ICatalogRepository, CatalogRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IRewardsAndBenefitsRepository, RewardsAndBenefitsRepository>();
            builder.Services.AddScoped<ICatalogService, CatalogService>();  
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IApplicationService, ApplicationService>();
            builder.Services.AddScoped<IItemPriceChangeService,  ItemPriceChangeService>();
            builder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                loggingBuilder.AddNLog();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}