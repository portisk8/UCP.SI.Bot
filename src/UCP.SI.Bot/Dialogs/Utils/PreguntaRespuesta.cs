using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UCP.SI.Bot.Entities.Entities;
using UCP.SI.Bot.Entities.Enums;

namespace UCP.SI.Bot.Dialogs.Utils
{
    public class PreguntaRespuesta
    {
        public int PreguntaId { get; set; }
        public string Pregunta { get; set; }
        public List<CustomChoice> Choices { get; set; }
		private readonly IStatePropertyAccessor<UserProfile> _userProfileAccessor;
		private readonly ConversationState _convesationState;
		private readonly UserState _userState;
        public string CardJson { get; set; }
        public bool IsCard => !string.IsNullOrEmpty(CardJson);

        public PreguntaRespuesta(UserState userState)
        {
            _userProfileAccessor = userState.CreateProperty<UserProfile>(nameof(UserProfile));
            _userState = userState;
        }

        public PreguntaRespuesta(UserState userState, int preguntaId, string pregunta, List<CustomChoice> choices)
        {
            PreguntaId = preguntaId;
            Pregunta = pregunta;
            Choices = choices;
			_userProfileAccessor = userState.CreateProperty<UserProfile>(nameof(UserProfile));
            _userState = userState;
        }


        public async Task<DialogTurnResult> PreguntaStep(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            if (IsCard)
            {
                var cardAttachment = new Attachment()
                {
                    ContentType = "application/vnd.microsoft.card.adaptive",
                    Content = JsonConvert.DeserializeObject(CardJson),
                };

                var options = new PromptOptions
                {
                    Prompt = new Activity
                    {
                        Attachments = new List<Attachment>() { cardAttachment },
                        Type = ActivityTypes.Message
                    }
                };

                return await stepContext.PromptAsync("cardAdaptive", options, cancellationToken);
            }

            if(Choices != null && Choices.Count > 0)
                return await stepContext.PromptAsync(nameof(ChoicePrompt),
                        new PromptOptions
                        {
                            Prompt = MessageFactory.Text(Pregunta),
                            Choices = Choices.Select(x => new Choice(x.Description)).ToArray()
                        }, cancellationToken);
            else
                return await stepContext.PromptAsync(nameof(TextPrompt),
                        new PromptOptions
                        {
                            Prompt = MessageFactory.Text(Pregunta)
                        }, cancellationToken);

        }
        public async Task<DialogTurnResult> RespuestaStep(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
			UserProfile profile = await _userProfileAccessor.GetAsync(stepContext.Context, () => new UserProfile(), cancellationToken);
            if (IsCard)
            {
                var jsonResult = stepContext.Result.ToString();
                var values = JsonConvert.DeserializeObject<Dictionary<AnswerEnum, bool>>(jsonResult);

                //await stepContext.Context.SendActivityAsync(MessageFactory.Text(jsonResult), cancellationToken);

                profile.PreguntaRespuestaDone.Add(new PreguntaRespuestaDone()
                {
                    Pregunta = Pregunta,
                    PreguntaId = PreguntaId,
                    ChoicesSelected = values.Where(x=> x.Value == true).Select(x=> new CustomChoice((AnswerEnum)x.Key)).ToList()
                });
            }
            else if(Choices != null && Choices.Count > 0)
            {
                var choice = stepContext.Result as FoundChoice;

                profile.PreguntaRespuestaDone.Add(new PreguntaRespuestaDone()
                {
                    Pregunta = Pregunta,
                    PreguntaId = PreguntaId,
                    ChoicesSelected = new List<CustomChoice> { Choices.Find(x => x.Description == choice?.Value) }
                });
            }
            else
            {
                var data = stepContext.Result.ToString().ToUpper();
                profile.PreguntaRespuestaDone.Add(new PreguntaRespuestaDone()
                {
                    Pregunta = Pregunta,
                    PreguntaId = PreguntaId,
                    ChoicesSelected = new List<CustomChoice> { new CustomChoice(0, data) },
                });
            }

            await _userProfileAccessor.SetAsync(stepContext.Context, profile);
            await _userState.SaveChangesAsync(stepContext.Context);

            return await stepContext.NextAsync(cancellationToken: cancellationToken);
        }



    }
}
