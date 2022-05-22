namespace UCP.SI.Bot.Entities.Cards
{
    public static class CustomAdaptiveCard
    {
        public static string TestReadCard()
        {
            string sb = "{" +
"  \"$schema\": \"http://adaptivecards.io/schemas/adaptive-card.json\"," +
"  \"type\": \"AdaptiveCard\"," +
"  \"version\": \"1.0\"," +
"  \"body\": [" +
"    {" +
"      \"type\": \"TextBlock\"," +
"      \"text\": \"Please enter deatils about the flight\"" +
"    }," +
"    {" +
"      \"type\": \"TextBlock\"," +
"      \"text\": \"Name:\"" +
"    }," +
"    {" +
"      \"type\": \"Input.Text\"," +
"      \"id\": \"Name\"," +
"      \"placeholder\": \"Name\"" +
"    }," +
"    {" +
"      \"type\": \"TextBlock\"," +
"      \"text\": \"Destination:\"" +
"    }," +
"    {" +
"      \"type\": \"Input.ChoiceSet\"," +
"      \"placeholder\": \"Destination\"," +
"      \"choices\": [" +
"        {" +
"          \"title\": \"Paris\"," +
"          \"value\": \"Paris\"" +
"        }," +
"        {" +
"          \"title\": \"New York\"," +
"          \"value\": \"New York\"" +
"        }," +
"        {" +
"          \"title\": \"London\"," +
"          \"value\": \"London\"" +
"        }" +
"      ]," +
"      \"id\": \"Destination\"," +
"      \"style\": \"expanded\"" +
"    }," +
"    {" +
"      \"type\": \"Input.Toggle\"," +
"      \"id\": \"OneWayFlight\"," +
"      \"title\": \"One Way Flight\"," +
"      \"value\": \"false\"" +
"    }" +
"  ]," +
"  \"actions\": [" +
"    {" +
"      \"type\": \"Action.Submit\"," +
"      \"title\": \"Submit\"" +
"    }" +
"  ]" +
"}";
            return sb;
        }

        public static string GetPaisajesQuestionCard()
        {
            return "{" +
"  \"$schema\": \"http://adaptivecards.io/schemas/adaptive-card.json\"," +
"  \"type\": \"AdaptiveCard\"," +
"  \"version\": \"1.0\"," +
"    \"body\": [" +
"        {" +
"            \"type\": \"TextBlock\"," +
"            \"size\": \"Medium\"," +
"            \"weight\": \"Bolder\"," +
"            \"text\": \"Paisajes que te gustan\"" +
"        }," +
"        {" +
"            \"type\": \"TextBlock\"," +
"            \"text\": \"Puedes seleccionar uno o varios\"," +
"            \"wrap\": true," +
"            \"spacing\": \"Small\"," +
"            \"separator\": true" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Montaña\"," +
"            \"id\": \"7\"" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Sierras\"," +
"            \"id\": \"8\"," +
"            \"separator\": true" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Llanura\"," +
"            \"separator\": true," +
"            \"id\": \"9\"" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Playa Río\"," +
"            \"id\": \"10\"," +
"            \"separator\": true" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Playa Mar\"," +
"            \"separator\": true," +
"            \"id\": \"11\"" +
"        }" +
"    ]," +
"    \"actions\": [" +
"        {" +
"            \"type\": \"Action.Submit\"," +
"            \"title\": \"Siguiente\"," +
"            \"style\": \"positive\"" +
"        }" +
"    ]" +
"}";
        }
        
        public static string GetAlojamientoQuestionCard()
        {
            return "{" +
"  \"$schema\": \"http://adaptivecards.io/schemas/adaptive-card.json\"," +
"  \"type\": \"AdaptiveCard\"," +
"  \"version\": \"1.0\"," +
"    \"body\": [" +
"        {" +
"            \"type\": \"TextBlock\"," +
"            \"size\": \"Medium\"," +
"            \"weight\": \"Bolder\"," +
"            \"text\": \"Alojamiento\"" +
"        }," +
"        {" +
"            \"type\": \"TextBlock\"," +
"            \"text\": \"Puedes seleccionar uno o varios\"," +
"            \"wrap\": true," +
"            \"spacing\": \"Small\"," +
"            \"separator\": true" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Casa/Departamento\"," +
"            \"id\": \"16\"" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Cabaña\"," +
"            \"id\": \"17\"," +
"            \"separator\": true" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Hotel\"," +
"            \"separator\": true," +
"            \"id\": \"18\"" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Camping\"," +
"            \"id\": \"19\"," +
"            \"separator\": true" +
"        }" +
"    ]," +
"    \"actions\": [" +
"        {" +
"            \"type\": \"Action.Submit\"," +
"            \"title\": \"Siguiente\"," +
"            \"style\": \"positive\"" +
"        }" +
"    ]" +
"}";
        }
        
        public static string GetActivitiesQuestionCard()
        {
            return "{" +
"  \"$schema\": \"http://adaptivecards.io/schemas/adaptive-card.json\"," +
"  \"type\": \"AdaptiveCard\"," +
"  \"version\": \"1.0\"," +
"    \"body\": [" +
"        {" +
"            \"type\": \"TextBlock\"," +
"            \"size\": \"Medium\"," +
"            \"weight\": \"Bolder\"," +
"            \"text\": \"Actividades que te gustaría realizar\"" +
"        }," +
"        {" +
"            \"type\": \"TextBlock\"," +
"            \"text\": \"Puedes seleccionar uno o varios\"," +
"            \"wrap\": true," +
"            \"spacing\": \"Small\"," +
"            \"separator\": true" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Senderismo\"," +
"            \"id\": \"23\"" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Playa\"," +
"            \"id\": \"24\"," +
"            \"separator\": true" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Paisajismo\"," +
"            \"separator\": true," +
"            \"id\": \"25\"" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Urbanismo\"," +
"            \"id\": \"26\"," +
"            \"separator\": true" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Campamento\"," +
"            \"id\": \"27\"," +
"            \"separator\": true" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Shopping\"," +
"            \"id\": \"28\"," +
"            \"separator\": true" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Ciclismo\"," +
"            \"id\": \"29\"," +
"            \"separator\": true" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Vida Nocturna\"," +
"            \"id\": \"30\"," +
"            \"separator\": true" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Cultura\"," +
"            \"id\": \"31\"," +
"            \"separator\": true" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Deportes Acuáticos\"," +
"            \"id\": \"32\"," +
"            \"separator\": true" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Deportes de nieve\"," +
"            \"id\": \"33\"," +
"            \"separator\": true" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Rafting\"," +
"            \"id\": \"34\"," +
"            \"separator\": true" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Escalada\"," +
"            \"id\": \"35\"," +
"            \"separator\": true" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Parque de diversiones\"," +
"            \"id\": \"36\"," +
"            \"separator\": true" +
"        }," +
"        {" +
"            \"type\": \"Input.Toggle\"," +
"            \"title\": \"Deportes Extremos\"," +
"            \"id\": \"37\"," +
"            \"separator\": true" +
"        }" +
"    ]," +
"    \"actions\": [" +
"        {" +
"            \"type\": \"Action.Submit\"," +
"            \"title\": \"Siguiente\"," +
"            \"style\": \"positive\"" +
"        }" +
"    ]" +
"}";
        }
    }
}
