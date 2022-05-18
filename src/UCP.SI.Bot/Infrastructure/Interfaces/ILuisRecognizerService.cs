using Microsoft.Bot.Builder.AI.Luis;

namespace UCP.SI.Bot.Infrastructure.Interfaces
{
    public interface ILuisRecognizerService
    {
        LuisRecognizer recognizer { get; }
    }
}
