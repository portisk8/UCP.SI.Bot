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

    }
}
