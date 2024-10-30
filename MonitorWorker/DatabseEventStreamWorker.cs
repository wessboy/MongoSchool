using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Persistance.Interfaces;
using Persistance.ValueObjects;

namespace MonitorWorker;
    public class DatabseEventStreamWorker : BackgroundService
    {
        private readonly SchoolDatabaseSettings _dbSettings;
        private readonly ILogger<DatabseEventStreamWorker> _logger;
        private readonly IMongoDbChangeStreamService _mongoDbChangeStreamService; 
        public DatabseEventStreamWorker(IOptions<SchoolDatabaseSettings> dbSettings,ILogger<DatabseEventStreamWorker> logger,IMongoDbChangeStreamService mongoDbChangeStreamService) 
        { 
            _dbSettings = dbSettings.Value;
            _logger = logger;
            _mongoDbChangeStreamService = mongoDbChangeStreamService;
        }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        _mongoDbChangeStreamService.InitiateStreamService(_dbSettings.ConnectionString, _dbSettings.DatabaseName, _dbSettings.StudentCollectionName);
        
        return base.StartAsync(cancellationToken);
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested) 
        {
           await Task.Run(() => _mongoDbChangeStreamService.StartListening(),stoppingToken);

            //await Task.Delay(100,stoppingToken);
        } 
    }
}

