using UCP.SI.Bot.Entities.Entities;
using UCP.SI.Bot.Entities.Enums;
using Microsoft.Bot.Builder.Adapters.Twilio;
using Microsoft.Bot.Schema;

namespace UCP.SI.Bot.EntitiesAdapter
{
    public class UserProfileEmulatorAdapter : UserProfile
    {
        public UserProfileEmulatorAdapter(ChannelTypeEnum channelTypeId, IMessageActivity activity) : base(channelTypeId)
        {
            Identifier = activity.From.Id;
        }
    }
}
