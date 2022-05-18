using UCP.SI.Bot.Infrastructure.Interfaces;
using Microsoft.Bot.Builder.AI.Luis;
using Microsoft.Bot.Builder.AI.QnA;
using Microsoft.Extensions.Configuration;

namespace UCP.SI.Bot.Infrastructure
{
    public class BotService : IBotService
    {
        public LuisRecognizer Recognizer { get; set; }
        public QnAMaker QnA { get; set; }

        public BotService(IConfiguration configuration)
        {
            //Luis configurations
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

            Recognizer = new LuisRecognizer(reconizerOptions);

            //QnA configurations
            QnA = new QnAMaker(new QnAMakerEndpoint
            {
                KnowledgeBaseId = configuration["QnAKnowledgebaseId"],
                EndpointKey = configuration["QnAEndpointKey"],
                Host = configuration["QnAEndpointHostName"]
            });
        }
    }
}
