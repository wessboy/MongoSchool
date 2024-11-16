using ExternalSerivces.Interfaces;
using ExternalSerivces.Services;
using Microsoft.Extensions.DependencyInjection;
using NLog;


namespace ExternalSerivces.ServicesConfiguration;
     public static class ExternalServiceDependancyInjection
    {
       
         public static IServiceCollection AddExternalServices(this IServiceCollection services)
        {
            string directoryPath = "C:/Users/hedhi/Desktop/TrialProjects/MongoSchool/ExternalSerivces/ServicesConfiguration";

            string filePath = string.Concat(directoryPath,"/nlog.config");

          
            LogManager.Setup().LoadConfigurationFromFile(filePath);

            services.AddSingleton<ILoggerService, LoggerService>();
          

            return services;
        }
    }

