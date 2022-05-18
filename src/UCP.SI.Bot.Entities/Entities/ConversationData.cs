using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCP.SI.Bot.Entities.Entities
{
	public class ConversationData
	{
		public DateTimeOffset LastActivity { get; set; }
		public UserProfile UserProfile { get; set; }
        public bool PreguntarSiNecesitaAlgoMas { get; set; }
	}
}
