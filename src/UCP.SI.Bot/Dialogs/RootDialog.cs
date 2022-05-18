using UCP.SI.Bot.Entities.Entities;
using UCP.SI.Bot.Infrastructure.Interfaces;
using UCP.SI.Bot.Core.Configurations.Interfaces;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.QnA.Dialogs;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UCP.SI.Bot.Dialogs
{
    public class RootDialog: ComponentDialog
    {
        /// <summary>
        /// QnA Maker initial dialog
        /// </summary>
        private const string InitialDialog = "initial-dialog";

        private readonly ConversationState _convesationState;
        protected readonly ICurrentConfiguration _currentConfiguration;
		private readonly IStatePropertyAccessor<UserProfile> _userProfileAccessor;
        private WaterfallStep[] _finalizarConversacionStep;
        private readonly IStatePropertyAccessor<ConversationData> _conversationDataAccessor;

        public RootDialog(ConversationState conversationState, 
            UserState userState,
            ICurrentConfiguration currentConfiguration) 
            : base(nameof(RootDialog))
        {
            _convesationState = conversationState;   
            _currentConfiguration = currentConfiguration;
			_userProfileAccessor = userState.CreateProperty<UserProfile>(nameof(UserProfile));
            _conversationDataAccessor = conversationState.CreateProperty<ConversationData>(nameof(ConversationData));
            var steps = new WaterfallStep[]
            {
                InitConversation,
                Dispatch,
            };

			AddDialog(new TextPrompt(nameof(TextPrompt)));
            AddDialog(new SugerirDestinoDialog(userState, currentConfiguration,conversationState));
			AddDialog(new ChoicePrompt(nameof(ChoicePrompt)));

            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), steps));

            // The initial child Dialog to run.
            InitialDialogId = nameof(WaterfallDialog);

        }

        private async Task<DialogTurnResult> InitConversation(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                    new PromptOptions
                    {
                        Prompt = MessageFactory.Text("¿Quieres empezar?"),
                        Choices = new[] { new Choice("Si"), new Choice("No") }
                    }, cancellationToken);
        }

        private async Task<DialogTurnResult> Dispatch(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
			UserProfile profile = await _userProfileAccessor.GetAsync(stepContext.Context, () => new UserProfile(), cancellationToken);
            var choice = stepContext.Result as FoundChoice;
            //Para que no vuelva a repetir la pregunta si tiene otra duda
            var conversation = await _conversationDataAccessor.GetAsync(stepContext.Context, () => new ConversationData { LastActivity = DateTimeOffset.UtcNow }, cancellationToken: cancellationToken);
            conversation.PreguntarSiNecesitaAlgoMas = false;
            if (choice?.Value == "Si")
            {
                return await stepContext.BeginDialogAsync(nameof(SugerirDestinoDialog), cancellationToken: cancellationToken);
                
            }
            else
            {
                await stepContext.Context.SendActivityAsync(MessageFactory.Text("Ok, estoy aquí por si me necesitas. Ten un buen día."), cancellationToken);
            }
            return await stepContext.EndDialogAsync(null, cancellationToken);

        }
    }
}
