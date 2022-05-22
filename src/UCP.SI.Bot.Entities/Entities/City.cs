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
        public string CityUrl { get; set; }
        public List<AnswerEnum> AnswerEnums { get; set; } = new List<AnswerEnum>();
        public List<CustomChoice> CustomChoices { get; set; }
        
        public int TotalMatch
        {
            get
            {
                var total2 = CustomChoices.Where(x=> x.IsAnswerEnum && AnswerEnums.Contains((AnswerEnum)x.Value)).Count();

                return total2;
            }
        }

        public decimal TotalPercent => TotalMatch * 100 / AnswerEnums.Count;
    }
}
