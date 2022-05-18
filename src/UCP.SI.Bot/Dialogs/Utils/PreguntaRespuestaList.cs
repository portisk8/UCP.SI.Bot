using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using System.Collections.Generic;
using UCP.SI.Bot.Entities.Entities;

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
                Pregunta = "Estacion del año?",
                PreguntaId = index++,
                Choices = new List<CustomChoice>() 
                            { new CustomChoice(1, "Verano"),
                            new CustomChoice(2, "Otoño"),
                            new CustomChoice(3, "Invierno"),
                            new CustomChoice(4, "Primavera"),
                            }
            });

            PreguntaRespuestas.Add(new PreguntaRespuesta(userState)
            {
                Pregunta = "Team Frio o Team Calor?",
                PreguntaId = index++,
                Choices = new List<CustomChoice>()
                            { new CustomChoice(1, "Team Frio"),
                            new CustomChoice(2, "Team Calor"),
                            }
            });

            PreguntaRespuestas.Add(new PreguntaRespuesta(userState)
            {
                Pregunta = "Tipo de paisaje?",
                PreguntaId = index++,
                Choices = new List<CustomChoice>()
                            { new CustomChoice(1, "Montaña"),
                            new CustomChoice(2, "Sierras"),
                            new CustomChoice(3, "Llanura"),
                            new CustomChoice(4, "Playa Rio"),
                            new CustomChoice(5, "Playa Mar"),
                            }
            });

            PreguntaRespuestas.Add(new PreguntaRespuesta(userState)
            {
                Pregunta = "Ciudad o Pueblo?",
                PreguntaId = index++,
                Choices = new List<CustomChoice>()
                            { new CustomChoice(1, "Ciudad"),
                            new CustomChoice(2, "Pueblo"),
                            }
            });

            PreguntaRespuestas.Add(new PreguntaRespuesta(userState)
            {
                Pregunta = "Cantidad de personas adultas?",
                PreguntaId = index++
            });

            PreguntaRespuestas.Add(new PreguntaRespuesta(userState)
            {
                Pregunta = "Cantidad de niños?",
                PreguntaId = index++
            });

            PreguntaRespuestas.Add(new PreguntaRespuesta(userState)
            {
                Pregunta = "Diurno o nocturno?",
                PreguntaId = index++,
                Choices = new List<CustomChoice>()
                            { new CustomChoice(1, "Diurno"),
                            new CustomChoice(2, "Nocturno"),
                            }
            });
        }

    }
}
