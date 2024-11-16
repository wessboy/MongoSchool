using ExternalSerivces.Interfaces;
using ExternalSerivces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExternalSerivces.ServicesConfiguration;
     public static class ExternalServiceDependancyInjection
    {
       
         public static IServiceCollection AddExternalServices(this IServiceCollection services)
        {
            string filePath = string.Concat("C:/Users/hedhi/Desktop/TrialProjects/MongoSchool/ExternalSerivces", "/nlog.config");

          
            LogManager.Setup().LoadConfigurationFromFile(filePath);

            services.AddSingleton<ILoggerService, LoggerService>();
          

            return services;
        }
    }

