using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace App.Common
{
    public class AppSettingHelper
    {
        public static IConfigurationSection GetSection(string sectionName)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            string appsettingFileName = "appsettings.json";
            if (!string.IsNullOrEmpty(environmentName))
                appsettingFileName = $"appsettings.{environmentName}.json";
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), appsettingFileName);
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();
            return root.GetSection(sectionName);
        }
    }
}
