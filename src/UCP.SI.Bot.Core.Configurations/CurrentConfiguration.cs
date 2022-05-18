using UCP.SI.Bot.Core.Configurations.Interfaces;
using Microsoft.Extensions.Configuration;
using UCP.SI.Bot.Core.Configurations;
using UCP.SI.Bot.Core.Configurations.Interfaces;

namespace UCP.SI.Bot.Core.Configurations
{
    public class CurrentConfiguration : ICurrentConfiguration
    {
        public IBotSettings BotSettings { get; set; }
        private static CurrentConfiguration _uniqueInstance;

        public CurrentConfiguration()
        {
        }

        public static ICurrentConfiguration Build(IConfiguration configuration)
        {
            var botSettings = new BotSettings();

            _uniqueInstance = new CurrentConfiguration { 
                BotSettings = botSettings.Build(configuration)
            };
            return _uniqueInstance;
        }
        public static CurrentConfiguration GetInstance()
        {
            return _uniqueInstance;
        }
    }
}