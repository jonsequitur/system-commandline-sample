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
    public static class CheckCommand
    {
        private static AppConfig config;

        /// <summary>
        /// Extension method to add the command
        /// </summary>
        /// <param name="parent">System.CommandLine.Command</param>
        public static void AddCheckCommand(this Command parent)
        {
            Command c = new ("check", "Check the app endpoint (if configured)");
            c.Handler = CommandHandler.Create<AppConfig>(DoCheckCommand);
            parent.AddCommand(c);
        }

        // command handler
        public static int DoCheckCommand(AppConfig appConfig)
        {
            config = appConfig;

            Console.WriteLine("Check Command");
            Console.WriteLine($"DryRun   {config.DryRun}");
            Console.WriteLine($"Verbose  {config.Verbose}");

            return 0;
        }
    }
}
