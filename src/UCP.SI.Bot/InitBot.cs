// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using UCP.SI.Bot.Dialogs;
using UCP.SI.Bot.Entities.Entities;
using UCP.SI.Bot.EntitiesAdapter;
using UCP.SI.Bot.Infrastructure;
using UCP.SI.Bot.Infrastructure.Interfaces;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Adapters.Twilio;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UCP.SI.Bot.Core.Configurations.Interfaces;

namespace UCP.SI.Bot
{
    public class InitBot<T> : ActivityHandler where T : Microsoft.Bot.Builder.Dialogs.Dialog
    {
        private readonly ConversationState _conversationState;
        private readonly UserState _userState;
        protected readonly Microsoft.Bot.Builder.Dialogs.Dialog _dialog;
        private readonly IStatePropertyAccessor<ConversationData> _conversationDataAccessor;
        private readonly IStatePropertyAccessor<UserProfile> _userProfileAccessor;
        private readonly IStatePropertyAccessor<DialogState> _dialogStateProfileAccessor;
        private readonly ICurrentConfiguration _currentConfiguration;

        public InitBot(ConversationState conversationState, UserState userState, T dialog, ICurrentConfiguration currentConfiguration)
        {
            _conversationState = conversationState;
            _dialog = dialog;
            _currentConfiguration = currentConfiguration;
            _conversationDataAccessor = conversationState.CreateProperty<ConversationData>(nameof(ConversationData));
            _userProfileAccessor = userState.CreateProperty<UserProfile>(nameof(UserProfile));
            _dialogStateProfileAccessor = _conversationState.CreateProperty<DialogState>(nameof(DialogState));
            _userState = userState;
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await _conversationState.DeleteAsync(turnContext, cancellationToken: cancellationToken);
                    await _userState.DeleteAsync(turnContext, cancellationToken: cancellationToken);
                    await turnContext.SendActivityAsync(MessageFactory.Text(_currentConfiguration.BotSettings.WelcomeMessage), cancellationToken);
                }
            }
        }

        public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
        {
            await  base.OnTurnAsync(turnContext, cancellationToken);
            await _conversationState.SaveChangesAsync(turnContext, cancellationToken: cancellationToken); 
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var conversation = await _conversationDataAccessor.GetAsync(turnContext, () => new ConversationData { LastActivity = DateTimeOffset.UtcNow }, cancellationToken: cancellationToken);
            if (DateTimeOffset.UtcNow.Subtract(conversation.LastActivity).TotalMinutes > _currentConfiguration.BotSettings.ConversationTimeoutInMinutes)
            {
                await _conversationState.DeleteAsync(turnContext, cancellationToken: cancellationToken);
                await _userState.DeleteAsync(turnContext, cancellationToken: cancellationToken);
            }
            conversation.LastActivity = DateTimeOffset.UtcNow;
            var profile = await _userProfileAccessor.GetAsync(turnContext, () => new UserProfile(), cancellationToken);
            if(profile.Token == null)
            {
                switch (turnContext.Activity.ChannelId)
                {
                    case "twilio-sms":
                        var twilioProfileData = new UserProfileTwilioAdapter(Entities.Enums.ChannelTypeEnum.BOT_WHATSAPP, turnContext.Activity.GetChannelData<TwilioMessage>());
                        profile.Identifier = twilioProfileData.Identifier;
                        profile.PhoneNumber = twilioProfileData.PhoneNumber;
                        profile.ChannelId = twilioProfileData.ChannelId;
                        profile.UserName = twilioProfileData.UserName;
                        profile.ChannelTypeId = Entities.Enums.ChannelTypeEnum.BOT_WHATSAPP;
                        break;
                    case "telegram":
                        var telegramProfileData = new UserProfileTelegramAdapter(Entities.Enums.ChannelTypeEnum.BOT_TELEGRAM, turnContext.Activity.GetChannelData<TelegramData>());
                        profile.Identifier = telegramProfileData.Identifier;
                        profile.PhoneNumber = telegramProfileData.PhoneNumber;
                        profile.ChannelId = telegramProfileData.ChannelId;
                        profile.UserName = telegramProfileData.UserName;
                        profile.ChannelTypeId = Entities.Enums.ChannelTypeEnum.BOT_TELEGRAM;
                        break;
                    case "webchat":
                        var webchatProfileData = new UserProfileEmulatorAdapter(Entities.Enums.ChannelTypeEnum.BOT_WEB, turnContext.Activity);
                        profile.Identifier = webchatProfileData.Identifier;
                        profile.ChannelId = webchatProfileData.ChannelId;
                        profile.ChannelTypeId = Entities.Enums.ChannelTypeEnum.BOT_WEB;
                        break;
                    default: //Emulator
                        var emaulatorProfileData = new UserProfileEmulatorAdapter(Entities.Enums.ChannelTypeEnum.BOT_EMULADOR, turnContext.Activity);
                        profile.Identifier = emaulatorProfileData.Identifier;
                        profile.ChannelId = emaulatorProfileData.ChannelId;
                        profile.ChannelTypeId = Entities.Enums.ChannelTypeEnum.BOT_EMULADOR;
                        break;
                }

                await _userProfileAccessor.SetAsync(turnContext, profile);
                await _userState.SaveChangesAsync(turnContext);
            }
            var message = turnContext.Activity.Text?.ToLower();
            if (!string.IsNullOrEmpty(message)
                && (message.Contains("cancelar") || message.Contains("terminar"))
                )
            {
                await _conversationState.DeleteAsync(turnContext, cancellationToken: cancellationToken);
            }
            conversation.UserProfile = profile;
            await _dialog.RunAsync(turnContext, _dialogStateProfileAccessor, cancellationToken);

        }
        protected override Task OnEndOfConversationActivityAsync(ITurnContext<IEndOfConversationActivity> turnContext, CancellationToken cancellationToken)
        {
            turnContext.SendActivityAsync(MessageFactory.Text("¿Deseas consultar algo mas?"), cancellationToken);
            return base.OnEndOfConversationActivityAsync(turnContext, cancellationToken);
        }

    }
}
