using UCP.SI.Bot.Infrastructure.Interfaces;
using Microsoft.Bot.Builder.AI.Luis;
using Microsoft.Extensions.Configuration;

namespace UCP.SI.Bot.Infrastructure
{
    public class LuisRecognizerService: ILuisRecognizerService
    {
        public LuisRecognizer recognizer { get; private set; }


        public LuisRecognizerService(IConfiguration configuration)
        {
            var luisApplication = new LuisApplication(
                configuration["LuisAppId"],
                configuration["LuisAPIKey"],
                configuration["LuisHostname"]);

            var reconizerOptions = new LuisRecognizerOptionsV3(luisApplication)
            {
                PredictionOptions = new Microsoft.Bot.Builder.AI.LuisV3.LuisPredictionOptions()
                {
                    IncludeInstanceData = true,
                }
            };

            recognizer = new LuisRecognizer(reconizerOptions);

        }

    }
}
