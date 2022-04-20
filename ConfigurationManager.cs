using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class ConfigurationManager
    {
        private static string _connectionString;

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                var builder = new ConfigurationBuilder();

                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json", false, true);

                var config = builder.Build();

                _connectionString = config["ConnectionStrings:SimpleSchool"];
            }

            return _connectionString;
        }
    }
}
