using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using System.Collections.Generic;
using UCP.SI.Bot.Entities.Cards;
using UCP.SI.Bot.Entities.Entities;
using UCP.SI.Bot.Entities.Enums;

namespace UCP.SI.Bot.Dialogs.Utils
{
    public class PreguntaRespuestaList
    {
        public List<PreguntaRespuesta> PreguntaRespuestas { get; set; } = new List<PreguntaRespuesta>();

        public PreguntaRespuestaList(UserState userState)
        {
            var index = 0;
            PreguntaRespuestas.Add(new PreguntaRespuesta(userState)
            {
                Pregunta = "Cual es tu nombre?",
                PreguntaId = index++
            });

            PreguntaRespuestas.Add(new PreguntaRespuesta(userState)
            {
                Pregunta = "Estacion del año favorita para viajar:",
                PreguntaId = index++,
                Choices = new List<CustomChoice>() 
                            { new CustomChoice((int)AnswerEnum.VERANO, AnswerEnum.VERANO.GetEnumDescription()),
                           new CustomChoice((int)AnswerEnum.OTOÑO, AnswerEnum.OTOÑO.GetEnumDescription()),
                           new CustomChoice((int)AnswerEnum.INVIERNO, AnswerEnum.INVIERNO.GetEnumDescription()),
                           new CustomChoice((int)AnswerEnum.PRIMAVERA, AnswerEnum.PRIMAVERA.GetEnumDescription()),
                            }
            });

            PreguntaRespuestas.Add(new PreguntaRespuesta(userState)
            {
                Pregunta = "Team Frio o Team Calor?",
                PreguntaId = index++,
                Choices = new List<CustomChoice>()
                            { 
                              new CustomChoice((int)AnswerEnum.TEAM_FRIO, AnswerEnum.TEAM_FRIO.GetEnumDescription()),
                              new CustomChoice((int)AnswerEnum.TEAM_CALOR, AnswerEnum.TEAM_CALOR.GetEnumDescription()),
                            }
            });

            PreguntaRespuestas.Add(new PreguntaRespuesta(userState)
            {
                Pregunta = "Paisajes que te gustan:",
                PreguntaId = index++,
                CardJson = CustomAdaptiveCard.GetPaisajesQuestionCard()
            });

            PreguntaRespuestas.Add(new PreguntaRespuesta(userState)
            {
                Pregunta = "Ciudad o Pueblo:",
                PreguntaId = index++,
                Choices = new List<CustomChoice>()
                            {
                              new CustomChoice((int)AnswerEnum.CIUDAD, AnswerEnum.CIUDAD.GetEnumDescription()),
                              new CustomChoice((int)AnswerEnum.PUEBLO, AnswerEnum.PUEBLO.GetEnumDescription()),
                            }
            });

            PreguntaRespuestas.Add(new PreguntaRespuesta(userState)
            {
                Pregunta = "Diurno o nocturno:",
                PreguntaId = index++,
                Choices = new List<CustomChoice>()
                            {
                              new CustomChoice((int)AnswerEnum.DIURNO, AnswerEnum.DIURNO.GetEnumDescription()),
                              new CustomChoice((int)AnswerEnum.NOCTURNO, AnswerEnum.NOCTURNO.GetEnumDescription()),
                            }
            });

            PreguntaRespuestas.Add(new PreguntaRespuesta(userState)
            {
                Pregunta = "Alojamiento:",
                PreguntaId = index++,
                CardJson = CustomAdaptiveCard.GetAlojamientoQuestionCard()
            });

            PreguntaRespuestas.Add(new PreguntaRespuesta(userState)
            {
                Pregunta = "Cantidad de días de estadía:",
                PreguntaId = index++,
                Choices = new List<CustomChoice>()
                            {
                              new CustomChoice((int)AnswerEnum.FIN_DE_SEMANA, AnswerEnum.FIN_DE_SEMANA.GetEnumDescription()),
                              new CustomChoice((int)AnswerEnum.SEMANA_COMPLETA, AnswerEnum.SEMANA_COMPLETA.GetEnumDescription()),
                              new CustomChoice((int)AnswerEnum.QUINCENA_O_MAS, AnswerEnum.QUINCENA_O_MAS.GetEnumDescription()),
                            }
            });

            PreguntaRespuestas.Add(new PreguntaRespuesta(userState)
            {
                Pregunta = "Actividades que te gustaría realizar:",
                PreguntaId = index++,
                CardJson = CustomAdaptiveCard.GetActivitiesQuestionCard()
            });
        }

    }
}
