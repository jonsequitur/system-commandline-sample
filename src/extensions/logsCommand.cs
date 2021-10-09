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
    public static class LogsCommand
    {
        private static AppConfig config;

        /// <summary>
        /// Extension method to add the command
        /// </summary>
        /// <param name="parent">System.CommandLine.Command</param>
        public static void AddLogsCommand(this Command parent)
        {
            Command c = new ("logs", "Get the Kubernetes app logs");
            c.Handler = CommandHandler.Create<AppConfig>(DoLogsCommand);
            parent.AddCommand(c);
        }

        // command handler
        public static int DoLogsCommand(AppConfig appConfig)
        {
            config = appConfig;

            Console.WriteLine("Logs Command");
            Console.WriteLine($"    DryRun   {LogsCommand.config.DryRun}");
            Console.WriteLine($"    Verbose  {LogsCommand.config.Verbose}");

            return 0;
        }
    }
}
