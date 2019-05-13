using Microsoft.Extensions.Configuration;
using System.IO;

namespace Moventure.DataLayer
{
    public class AppConfiguration
    {
        private static string mConnectionString = string.Empty;

        public static void Init()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            mConnectionString = root.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        }
        public static string ConnectionString
        {
            get => mConnectionString;
        }

    }
}
