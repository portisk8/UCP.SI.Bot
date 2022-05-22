using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCP.SI.Bot.Entities.Enums;

namespace UCP.SI.Bot.Entities.Entities
{
    public class City
    {
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public int CityId { get; set; }
        public List<AnswerEnum> AnswerEnums { get; set; } = new List<AnswerEnum>();
    }
}
