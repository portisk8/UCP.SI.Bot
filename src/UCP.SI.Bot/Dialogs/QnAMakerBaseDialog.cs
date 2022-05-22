using UCP.SI.Bot.Infrastructure;
using UCP.SI.Bot.Infrastructure.Interfaces;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.QnA;
using Microsoft.Bot.Builder.AI.QnA.Dialogs;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System.Threading;
using System.Threading.Tasks;
using UCP.SI.Bot.Core.Configurations;
using UCP.SI.Bot.Core.Configurations.Interfaces;

namespace UCP.SI.Bot.Dialogs
{
    public class QnAMakerBaseDialog : QnAMakerDialog
    {
        private readonly IBotService _service;

        // Dialog Options parameters
        public const string DefaultCardTitle = "Did you mean:";
        public const string DefaultCardNoMatchText = "None of the above.";
        public const string DefaultCardNoMatchResponse = "Thanks for the feedback.";
        private readonly ICurrentConfiguration _currentConfiguration;


        public QnAMakerBaseDialog(IBotService service, ICurrentConfiguration currentConfiguration) : base()
        {
            this._service = service;
            _currentConfiguration = currentConfiguration;
        }

        protected async override Task<IQnAMakerClient> GetQnAMakerClientAsync(DialogContext dc)
        {
            return this._service?.QnA;
        }

        protected override Task<QnAMakerOptions> GetQnAMakerOptionsAsync(DialogContext dc)
        {
            return Task.FromResult(new QnAMakerOptions
            {
                ScoreThreshold = 0.6f, //Confidence Score
                Top = DefaultTopN,
                QnAId = 0,
                RankerType = "Default",
                IsTest = false,
            });
        }

        protected async override Task<QnADialogResponseOptions> GetQnAResponseOptionsAsync(DialogContext dc)
        {
            var noAnswer = (Activity)Activity.CreateMessageActivity();
            //noAnswer.Text = _settings.QnaDefaultNoAnswer;
            noAnswer.Text = "No se que responder";

            var cardNoMatchResponse = (Activity)MessageFactory.Text(DefaultCardNoMatchResponse);


            var responseOptions = new QnADialogResponseOptions
            {
                ActiveLearningCardTitle = DefaultCardTitle,
                CardNoMatchText = DefaultCardNoMatchText,
                NoAnswer = noAnswer,
                CardNoMatchResponse = cardNoMatchResponse,
            };

            return responseOptions;
        }

    }
}
