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
    public static class SyncCommand
    {
        private static AppConfig config;

        /// <summary>
        /// Extension method to add the command
        /// </summary>
        /// <param name="parent">System.CommandLine.Command</param>
        public static void AddSyncCommand(this Command parent)
        {
            Command c = new ("sync", "Sync any GitOps changes");
            c.Handler = CommandHandler.Create<AppConfig>(DoSyncCommand);
            parent.AddCommand(c);
        }

        // command handler
        public static int DoSyncCommand(AppConfig appConfig)
        {
            config = appConfig;

            Console.WriteLine("Sync Command");
            Console.WriteLine($"    DryRun   {config.DryRun}");
            Console.WriteLine($"    Verbose  {config.Verbose}");

            return 0;
        }
    }
}
