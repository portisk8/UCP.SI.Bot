﻿using UCP.SI.Bot.Entities.Entities;

namespace UCP.SI.Bot.Entities.Entities
{
    public class PreguntaRespuestaDone
    {
        public int PreguntaId { get; set; }
        public string Pregunta { get; set; }
        public CustomChoice ChoiceSelected { get; set; }
    }
}
