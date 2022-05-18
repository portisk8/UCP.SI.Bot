using Microsoft.Bot.Builder.AI.Luis;
using Microsoft.Bot.Builder.AI.QnA;

namespace UCP.SI.Bot.Infrastructure.Interfaces
{
    public interface IBotService
    {
        LuisRecognizer Recognizer { get; set; }
        QnAMaker QnA { get; set; }
    }
}
