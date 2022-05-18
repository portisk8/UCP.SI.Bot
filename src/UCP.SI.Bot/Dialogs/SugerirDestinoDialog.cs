using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UCP.SI.Bot.Core.Configurations.Interfaces;
using UCP.SI.Bot.Dialogs.Utils;
using UCP.SI.Bot.Entities.Cards;
using UCP.SI.Bot.Entities.Entities;

namespace UCP.SI.Bot.Dialogs
{
    public class SugerirDestinoDialog : ComponentDialog
    {
		private readonly IStatePropertyAccessor<UserProfile> _userProfileAccessor;
		private readonly ConversationState _convesationState;
		private readonly UserState _userState;
		private readonly ICurrentConfiguration _currentConfiguration;
		private WaterfallStep[] _preguntasStep;

		public SugerirDestinoDialog(
							UserState userState,
							ICurrentConfiguration currentConfiguration,
							ConversationState convesationState)
			: base(nameof(SugerirDestinoDialog))
		{
			_userState = userState;
			_userProfileAccessor = userState.CreateProperty<UserProfile>(nameof(UserProfile));
			_convesationState = convesationState;
			_currentConfiguration = currentConfiguration;

			//Armo los steps. dentro de la clase PreguntaRespuestaList se arman las preguntas y respuestas
			var preguntasRespuestasList = new PreguntaRespuestaList(userState);
			List<WaterfallStep> listadoSteps = new List<WaterfallStep>();
			foreach (var step in preguntasRespuestasList.PreguntaRespuestas)
            {
				listadoSteps.Add(step.PreguntaStep);
				listadoSteps.Add(step.RespuestaStep);
			}
			//Steps extras
			listadoSteps.Add(ShowResults); 
			_preguntasStep = listadoSteps.ToArray();

			AddDialog(new WaterfallDialog(nameof(WaterfallDialog) + "_preguntasStep", _preguntasStep));

			AddDialog(new TextPrompt(nameof(TextPrompt)));
			AddDialog(new ChoicePrompt(nameof(ChoicePrompt)));

			AddDialog(new AdaptiveCardPrompt("PrimerPreguntaCard"));
			InitialDialogId = nameof(WaterfallDialog) + "_preguntasStep";
		}

        private async Task<DialogTurnResult> ShowResults(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
			UserProfile profile = await _userProfileAccessor.GetAsync(stepContext.Context, () => new UserProfile(), cancellationToken);
			var message = new StringBuilder();
			var index = 0;
			foreach (var item in profile.PreguntaRespuestaDone)
            {
				message.AppendLine($"**{index++})** [{item.PreguntaId}] {item.Pregunta}");
				message.AppendLine($"> Respuesta: ***{item.ChoiceSelected.Description}***");
			}
			await stepContext.Context.SendActivityAsync(MessageFactory.Text("Tus respuestas:"), cancellationToken);
			await stepContext.Context.SendActivityAsync(MessageFactory.Text(message.ToString()), cancellationToken);

			return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
		}
	}
}
