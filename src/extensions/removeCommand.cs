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
    public static class RemoveCommand
    {
        private static AppConfig config;

        /// <summary>
        /// Extension method to add the command
        /// </summary>
        /// <param name="parent">System.CommandLine.Command</param>
        public static void AddRemoveCommand(this Command parent)
        {
            Command c = new ("remove", "Remove app from GitOps");
            c.AddAlias("rm");
            c.Handler = CommandHandler.Create<AppConfig>(DoRemoveCommand);
            parent.AddCommand(c);
        }

        // command handler
        public static int DoRemoveCommand(AppConfig appConfig)
        {
            config = appConfig;

            Console.WriteLine("Remove Command");
            Console.WriteLine($"    DryRun   {config.DryRun}");
            Console.WriteLine($"    Verbose  {config.Verbose}");

            return 0;
        }
    }
}
