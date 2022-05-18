using UCP.SI.Bot.Entities.Entities;
using UCP.SI.Bot.Entities.Enums;
using Microsoft.Bot.Builder.Adapters.Twilio;

namespace UCP.SI.Bot.EntitiesAdapter
{
    public class UserProfileTwilioAdapter: UserProfile
    {
        public UserProfileTwilioAdapter (ChannelTypeEnum channelTypeId, TwilioMessage channelData): base(channelTypeId)
        {
            UserName = channelData.Author;
            PhoneNumber = channelData.From;
            Identifier = channelData.From;
        }
    }
}
