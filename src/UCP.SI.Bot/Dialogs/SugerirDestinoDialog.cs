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
using UCP.SI.Bot.Entities.Factories;

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
			AddDialog(new AdaptiveCardPrompt("cardAdaptive"));

			AddDialog(new AdaptiveCardPrompt("PrimerPreguntaCard"));
			InitialDialogId = nameof(WaterfallDialog) + "_preguntasStep";
		}

        private async Task<DialogTurnResult> ShowResults(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
			UserProfile profile = await _userProfileAccessor.GetAsync(stepContext.Context, () => new UserProfile(), cancellationToken);
			var message = new StringBuilder();
			var index = 0;
			var customChiceList = new List<CustomChoice>();
			//Muestro las respuestas del usuario
			foreach (var item in profile.PreguntaRespuestaDone)
            {
				message.AppendLine($"**{index++})** [{item.PreguntaId}] {item.Pregunta}");
				message.AppendLine($"> Respuesta:");
                foreach (var answer in item.ChoicesSelected)
                {
					message.AppendLine($"> ***{answer.Description}***");
                }
				customChiceList.AddRange(item.ChoicesSelected);
			}
			await stepContext.Context.SendActivityAsync(MessageFactory.Text("Tus respuestas:"), cancellationToken);
			await stepContext.Context.SendActivityAsync(MessageFactory.Text(message.ToString()), cancellationToken);
			//Obtengo el Top10 de las ciudades
			var top10Cities = GetTop10Cities(customChiceList);
			message = new StringBuilder();
			message.AppendLine($"**Top 10 de los lugares recomendados:**");
			index = 1;
			foreach (var city in top10Cities)
            {
				message.AppendLine($"> **{index++}°** {city.CityName} {city.TotalMatch}/{city.AnswerEnums.Count} ({city.TotalPercent}%)");
			}
			await stepContext.Context.SendActivityAsync(MessageFactory.Text(message.ToString()), cancellationToken);

			//Limpiamos el Profile para empezar de nuevo con las preguntas
			profile.Clear();
			await _userProfileAccessor.SetAsync(stepContext.Context, profile);
			await _userState.SaveChangesAsync(stepContext.Context);

			return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
		}

		private List<City> GetTop10Cities(List<CustomChoice> customChoices)
        {
			var cityListReturn = new List<City>();
			var cityList = CityFactory.GetCities();
			foreach (var city in cityList)
            {
				city.CustomChoices = customChoices;
            }
			return cityList.OrderByDescending(x=> x.TotalPercent).Take(10).ToList();
        }
	}
}
