// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace SCL.CommandLine.Extensions
{
    /// <summary>
    /// System.CommandLine.Command extension
    /// </summary>
    public static class NewCommand
    {
        private static AppConfig config;

        /// <summary>
        /// Extension method to add the command
        /// </summary>
        /// <param name="parent">System.CommandLine.Command</param>
        public static void AddNewCommand(this Command parent)
        {
            Command dotnet = new ("dotnet", "Create a new Dotnet WebAPI app");
            dotnet.Handler = CommandHandler.Create<AppConfig>(DoDotnetCommand);

            Command appNew = new ("new", "Create a new app");

            appNew.AddCommand(dotnet);
            parent.AddCommand(appNew);
        }

        // command handler
        public static int DoDotnetCommand(AppConfig appConfig)
        {
            config = appConfig;

            Console.WriteLine("New Dotnet Command");
            Console.WriteLine($"    DryRun   {config.DryRun}");
            Console.WriteLine($"    Verbose  {config.Verbose}");

            return 0;
        }
    }
}
