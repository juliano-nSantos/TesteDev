using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infra.Infra.Shared.Utils
{
    public static class Constants
    {
        private static IConfigurationBuilder GetConfigurationBuilder()
        {
            return new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");
        }

        public static string GetConnectionString()
        {
            var builder = GetConfigurationBuilder();
            var config = builder.Build();

            return config[$"ConnectionStrings:Connection"];
        }
    }
}