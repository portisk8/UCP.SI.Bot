using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCP.SI.Bot.Entities.Entities.Bot
{
    public class UserBotClient
    {
        public int? UserBotId { get; set; }
        public string Identificador { get; set; }
        public string Canal { get; set; }
        public string Hash { get; set; }
        public string Token { get; set; }
        public int? UsuarioId { get; set; }

    }
}
