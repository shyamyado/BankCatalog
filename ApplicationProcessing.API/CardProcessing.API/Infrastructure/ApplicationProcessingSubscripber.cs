
using ApplicationEventBus;
using ApplicationProcessing.API.Services;

namespace ApplicationProcessing.API.Infrastructure
{
    //public class ApplicationProcessingSubscripber : IHostedService, IDisposable
    //{

    //    private readonly IRabbitMQPersistantConnection _rabbitMQPersistantConnection;
    //    private readonly ILogger<ApplicationProcessingSubscripber> _logger;
    //    private Timer? _timer;

    //    public ApplicationProcessingSubscripber(IRabbitMQPersistantConnection rabbitMQPersistantConnection, ILogger<ApplicationProcessingSubscripber> logger)
    //    {
    //        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    //        _rabbitMQPersistantConnection = rabbitMQPersistantConnection ?? throw new ArgumentNullException(nameof(rabbitMQPersistantConnection));
    //    }


    //    public Task StartAsync(CancellationToken cancellationToken)
    //    {
    //        _logger.LogInformation("Application Processing Subscriber is starting.");
    //        //_timer = new Timer(SubscribeToQueue, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
    //        SubscribeToQueue();
    //        return Task.CompletedTask;
    //    }

    //    private void SubscribeToQueue()
    //    {
    //        string eventMsgQueueName = "new_application";
    //        _rabbitMQPersistantConnection.Subscribe(eventMsgQueueName);
    //        Console.WriteLine(eventMsgQueueName);
    //        _logger.LogInformation("Application Processing Subscriber is working.");
    //    }

    //    public Task StopAsync(CancellationToken cancellationToken)
    //    {
    //        _logger.LogInformation("Application Processing Subscriber is stopping.");
    //        _timer?.Change(Timeout.Infinite, 0);
    //        return Task.CompletedTask;
    //    }


    //    public void Dispose()
    //    {
    //        _timer?.Dispose();
    //    }





    //}

    public class ApplicationProcessingSubscripber : BackgroundService
    {
        private readonly ILogger<ApplicationProcessingSubscripber> _logger;
        private readonly IRabbitMQPersistantConnection _rabbitMQPersistantConnection;

        public ApplicationProcessingSubscripber(IServiceProvider services,
            ILogger<ApplicationProcessingSubscripber> logger,
            IRabbitMQPersistantConnection rabbitMQPersistantConnection)
        {
            Services = services;
            _logger = logger;
            _rabbitMQPersistantConnection = rabbitMQPersistantConnection;
        }

        public IServiceProvider Services { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Consume Scoped Service Hosted Service running.");

            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            _logger.LogInformation( "Consume Scoped Service Hosted Service is working.");
            string eventMsgQueueName = "new_application";
            _rabbitMQPersistantConnection.Subscribe(eventMsgQueueName);
            Console.WriteLine("Hello RabbitMQ event");
            _logger.LogInformation("Application Processing Subscriber is working.");

        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Consume Scoped Service Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}
