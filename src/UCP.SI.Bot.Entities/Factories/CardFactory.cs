using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Bot.Schema;

namespace UCP.SI.Bot.Entities.Factories
{
    public class CardFactory
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public IList<CardAction> Actions { get; set; } = new List<CardAction>();
        public IList<CardImage> Images { get; set; } = new List<CardImage>();

        public CardFactory()
        {
        }
        public CardFactory(string title, string text)
        {
            Title = title;
            Text = text;
		}
		public CardFactory(string title, string text, IList<CardAction> actions)
		{
			Title = title;
			Text = text;
			Actions = actions;
		}
		public CardFactory(string title, string text, IList<CardAction> actions, IList<CardImage> images)
		{
			Title = title;
			Text = text;
			Actions = actions;
			Images = images;
		}
		public Activity CreateCard()
		{
			var card = new HeroCard();
			card.Title = Title;
			card.Text = Text;
			card.Buttons = Actions;

			var message = (Activity)Activity.CreateMessageActivity();
			message.Attachments.Add(new Attachment
			{
				ContentType = HeroCard.ContentType,
				Content = card
			});
			return message;
		}
	}
}
