using System;
using System.Collections.Generic;
using Changelog_History.Enums;
using Changelog_History.Managers;
using Changelog_History.Managers.Interfaces;
using Changelog_History.Repository.FileRepository;
using Changelog_History.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NDesk.Options;
using Newtonsoft.Json;

namespace Changelog_History
{
    public static class Program
    {
        public static IServiceCollection AddManagers(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<IGitManager, GitManager>()
                .AddSingleton<IMainManager, MainManager>();
        }

         public static IServiceCollection AddFileRepositories(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<IProjectRepository, ProjectFileRepository>();
        }

        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging(t => t.AddConsole())
                .AddManagers()
                .AddFileRepositories()
                .BuildServiceProvider();

            //configure console logging
            // serviceProvider
            //     .GetService<ILoggingFactory>()
            //     .AddConsole();

            // using (var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()))
            // {
            // }
            // var logger = serviceProvider.GetService<ILoggerFactory>()
            // .CreateLogger<Program>();

            StartType? startType = null;

            string project = string.Empty;
            string reference1 = string.Empty;

            var p = new OptionSet () 
            {
                { "p|project|c|context=", arg => { project = arg; } },
                { "ap|add-project=", arg => { startType = StartType.AddProject; project = arg; } },
                { "ac|add-category=",  arg => { startType = StartType.AddCategory; reference1 = arg; } },
                { "rap|read-all-projects",  arg => { startType = StartType.ReadAllProjects; } },
                { "rp|read-project=",  arg => { startType = StartType.ReadProject; project = arg; } },
            };

            List<string> extra = p.Parse(args);

            switch(startType)
            {
                case StartType.AddCategory:
                    serviceProvider.GetService<IMainManager>().AddCategory(project, reference1);
                    break;
                case StartType.AddProject:
                    serviceProvider.GetService<IMainManager>().AddProject(project);
                    break;
                case StartType.ReadAllProjects:
                    Console.Write(JsonConvert.SerializeObject(serviceProvider.GetService<IMainManager>().ReadProjects(), Formatting.Indented));
                    break;
                case StartType.ReadProject:
                    Console.Write(JsonConvert.SerializeObject(serviceProvider.GetService<IMainManager>().ReadProject(project), Formatting.Indented));
                    break;
                default:
                    break;
            }
        }
    }
}
