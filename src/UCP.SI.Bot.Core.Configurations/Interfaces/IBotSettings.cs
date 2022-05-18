using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCP.SI.Bot.Core.Configurations.Interfaces
{
    public interface IBotSettings
    {
        string BotName { get; set; }
        string BotVersion { get; set; }
        int ConversationTimeoutInMinutes { get; set; }
        string CompanyName { get; set; }
        string WelcomeMessage { get; set; }

    }
}
