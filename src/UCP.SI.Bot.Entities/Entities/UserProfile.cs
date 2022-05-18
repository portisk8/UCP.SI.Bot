using UCP.SI.Bot.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCP.SI.Bot.Entities.Entities
{
    public class UserProfile
    {
        public ChannelTypeEnum ChannelTypeId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Identifier { get; set; }
        public string? Hash { get; set; }
        public string? ChannelId { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public List<PreguntaRespuestaDone> PreguntaRespuestaDone { get; set; } = new List<PreguntaRespuestaDone>();

        public UserProfile(ChannelTypeEnum channelTypeId)
        {
            ChannelTypeId = channelTypeId;
        }

        public UserProfile()
        {
        }


        public void Clear()
        {
            Token = string.Empty;
        }
    }
}
