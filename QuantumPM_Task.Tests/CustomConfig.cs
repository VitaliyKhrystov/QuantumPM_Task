
using Microsoft.Extensions.Configuration;

namespace QuantumPM_Task.Tests
{
    public class CustomConfig
    {
        public static IConfiguration Get()
        {
            var myConfiguration = new Dictionary<string, string>
                {
                    {"Logging:LogLevel:Default", "Information" },
                    {"Logging:LogLevel:Microsoft.AspNetCore", "Warning" },
                    {"AllowedHost", "*" },
                    {"maxTitleLength", "45" },
                    {"maxContentLength", "1000" },
                    {"ConnectionString", "Host=localhost;Port=5432;Database=QuantumPMDB;Username=postgres;Password=Vitalik1119028" }
                };
            return new ConfigurationBuilder().AddInMemoryCollection(myConfiguration).Build();
        }
    }
}
