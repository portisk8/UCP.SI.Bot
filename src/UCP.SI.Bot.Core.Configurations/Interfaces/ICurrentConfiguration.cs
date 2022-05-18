
using UCP.SI.Bot.Core.Configurations.Interfaces;

namespace UCP.SI.Bot.Core.Configurations.Interfaces
{
    public interface ICurrentConfiguration
    {
        public IBotSettings BotSettings { get; set; }

    }
}
