﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SafeAuto.Kata.Repositories;
using SafeAuto.Kata.Repositories.Interfaces;
using SafeAuto.Kata.Services;
using SafeAuto.Kata.Services.Interfaces;

namespace SafeAuto.Kata.FileProcessor.Config
{
    public static class Setup
    {
        public static ServiceProvider ConfigureDependencyInjection()
        {
            var serviceProvider = new ServiceCollection()
                // configure repositories
                .AddSingleton<IUserRepository, UserRepository>()

                // configure services
                .AddSingleton<IFileReaderService, FileReaderService>()
                .AddSingleton<ITripCalculatorService, TripCalculatorService>()
                .AddSingleton<IValidationService, ValidationService>()
                .AddSingleton<IPrintService, PrintService>()

                // configure logging
                .AddSingleton<ILoggerFactory, LoggerFactory>()
                .AddSingleton(typeof(ILogger<>), typeof(Logger<>))
                .AddLogging(loggingBuilder => loggingBuilder
                    .AddDebug()
                    .SetMinimumLevel(LogLevel.Debug)
                )
                .BuildServiceProvider()
                ;

            return serviceProvider;
        }
    }
}