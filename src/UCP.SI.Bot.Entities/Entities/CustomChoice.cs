namespace UCP.SI.Bot.Entities.Entities
{
    public class CustomChoice
    {
        public CustomChoice(int value, string description)
        {
            Description = description;
            Value = value;
        }

        public string Description { get; set; }
        public int Value { get; set; }
    }
}
