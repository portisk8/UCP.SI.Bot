using UCP.SI.Bot.Entities.Enums;

namespace UCP.SI.Bot.Entities.Entities
{
    public class CustomChoice
    {
        public CustomChoice() { }
        public CustomChoice(AnswerEnum answerEnum)
        {
            Description = answerEnum.GetEnumDescription();
            Value = (int)answerEnum;
        }

        public CustomChoice(int value, string description)
        {
            Description = description;
            Value = value;
        }

        public string Description { get; set; }
        public int Value { get; set; }
        public bool IsAnswerEnum => Value.IsAnswerEnum();
    }
}
