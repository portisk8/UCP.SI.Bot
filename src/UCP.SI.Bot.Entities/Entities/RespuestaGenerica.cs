using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCP.SI.Bot.Entities.Entities
{
    public class RespuestaGenerica
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public long? Id { get; set; }
    }
}
