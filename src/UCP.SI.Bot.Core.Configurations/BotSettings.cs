using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCP.SI.Bot.Core.Configurations.Interfaces;

namespace UCP.SI.Bot.Core.Configurations
{
    public class BotSettings : IBotSettings
    {
        private IConfiguration configuration;

        public BotSettings() { }
        public BotSettings(IConfiguration configuration)
        {
            this.configuration = configuration;
            ConversationTimeoutInMinutes = int.Parse(configuration["Bot:ConversationTimeoutInMinutes"]);
            CompanyName = configuration["Bot:CompanyName"];
            BotName = configuration["Bot:BotName"];
            WelcomeMessage = configuration["Bot:WelcomeMessage"];
        }
        public IBotSettings Build(IConfiguration configuration)
        {
            return new BotSettings(configuration);
        }

        public string BotName { get; set; }
        public string BotVersion { get; set; }
        public int ConversationTimeoutInMinutes { get; set; }
        public string CompanyName{ get; set; }
        public string WelcomeMessage{ get; set; }

    }
}
