// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EmptyBot v4.15.0

using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace UCP.SI.Bot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ASP.NET Core 3.0+:
            // The UseServiceProviderFactory call attaches the
            // Autofac provider to the generic hosting mechanism.
            var host = Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webHostBuilder => {
                    webHostBuilder
              .UseContentRoot(Directory.GetCurrentDirectory())
              .UseIISIntegration()
              .UseStartup<Startup>();
                })
                .Build();

            host.Run();
        }

    }
}
