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
    public static class ListCommand
    {
        private static AppConfig config;

        /// <summary>
        /// Extension method to add the command
        /// </summary>
        /// <param name="parent">System.CommandLine.Command</param>
        public static void AddListCommand(this Command parent)
        {
            Command c = new ("list", "List the apps running in Kubernetes");
            c.AddAlias("ls");
            c.Handler = CommandHandler.Create<AppConfig>(DoListCommand);
            parent.AddCommand(c);
        }

        // command handler
        public static int DoListCommand(AppConfig appConfig)
        {
            config = appConfig;

            Console.WriteLine("List Command");
            Console.WriteLine($"    DryRun   {config.DryRun}");
            Console.WriteLine($"    Verbose  {config.Verbose}");

            return 0;
        }
    }
}
