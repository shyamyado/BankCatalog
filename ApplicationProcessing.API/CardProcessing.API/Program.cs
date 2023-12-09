using ApplicationEventBus;
using ApplicationProcessing.API.Infrastructure;
using ApplicationProcessing.API.Infrastructure.Repositories;
using ApplicationProcessing.API.Services;
using NLog.Extensions.Logging;
using RabbitMQ.Client;

namespace ApplicationProcessing.API
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

            builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            builder.Services.AddHostedService<ApplicationProcessingSubscripber>();
            //builder.Services.AddSingleton<IRabbitMQPersistantConnection, RabbitMQPersistantConnection>();
            builder.Services.AddScoped<ApplicationProcessingSubscripber>();
            builder.Services.AddDbContext<ApplicationDBContext>();
            builder.Services.AddScoped<IApplicantService, ApplicantService>();
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();

            //builder.Services.AddHostedService<ConsumeScopedServiceHostedService>();
            //builder.Services.AddScoped<IScopedProcessingService, ScopedProcessingService>();

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
