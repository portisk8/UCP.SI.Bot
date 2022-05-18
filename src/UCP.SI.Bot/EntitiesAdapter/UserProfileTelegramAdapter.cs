using UCP.SI.Bot.Entities.Entities;
using UCP.SI.Bot.Entities.Enums;
using Microsoft.Bot.Builder.Adapters.Twilio;

namespace UCP.SI.Bot.EntitiesAdapter
{
    public class UserProfileTelegramAdapter : UserProfile
    {
        public UserProfileTelegramAdapter(ChannelTypeEnum channelTypeId, TelegramData channelData): base(channelTypeId)
        {
            UserName = channelData.message.from.first_name ?? channelData.message.from.username;
            Identifier = channelData.message.from.id.ToString();
        }
    }
}
