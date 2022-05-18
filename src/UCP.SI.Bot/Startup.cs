﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EmptyBot v4.15.0

using Autofac;
using Autofac.Extensions.DependencyInjection;
using UCP.SI.Bot.Dialogs;
using UCP.SI.Bot.Core.Configurations.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace UCP.SI.Bot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static ICurrentConfiguration CurrentConfiguration { get; set; }
        public ILifetimeScope AutofacContainer { get; private set; }
        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient()
                .AddControllers()
                .AddNewtonsoftJson();
            services.AddLogging();

            // Create the Bot Framework Authentication to be used with the Bot Adapter.
            services.AddSingleton<BotFrameworkAuthentication, ConfigurationBotFrameworkAuthentication>();

            // Create the Bot Adapter with error handling enabled.
            services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();


            //Armar configuracion general
            CurrentConfiguration =  UCP.SI.Bot.Core.Configurations.CurrentConfiguration.Build(Configuration);
            services.AddSingleton(CurrentConfiguration);


            services.AddSingleton<RootDialog>();
            //services.AddSingleton<ILuisRecognizerService, LuisRecognizerService>();

            // Create the storage we'll be using for User and Conversation state. (Memory is great for testing purposes.)
            services.AddSingleton<IStorage, MemoryStorage>();

            // Create the User state. (Used in this bot's Dialog implementation.)
            services.AddSingleton<UserState>();
            // Create the Conversation state. (Used by the Dialog system itself.)
            services.AddSingleton<ConversationState>();

            //// Create the Bot Framework Twilio Adapter.
            // Create the Twilio Adapter
            //services.AddSingleton<Microsoft.Bot.Builder.Adapters.Twilio.TwilioAdapter, Adapters.TwilioAdapterWithErrorHandler>();

            //services.AddSingleton<IBotService, BotService>();

            //Para solucionar issue:  https://stackoverflow.com/questions/67816160/how-to-close-the-qnamker-dialog-while-using-multiturn-qna-kb-and-luis-with-the-h
            //https://github.com/microsoft/BotBuilder-Samples/issues/3194
            ComponentRegistration.Add(new DialogsComponentRegistration());


            // Create the bot as a transient. In this case the ASP Controller is expecting an IBot.
            services.AddTransient<IBot, InitBot<RootDialog>>();
        }


        public void ConfigureContainer(ContainerBuilder builder)
        {

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles()
                .UseStaticFiles()
                .UseWebSockets()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

            // app.UseHttpsRedirection();
        }
    }
}
