// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace SCL.CommandLine.Extensions
{
    public static class AddCommand
    {
        private static AppConfig config;

        /// <summary>
        /// Extension method to add the command
        /// </summary>
        /// <param name="parent">System.CommandLine.Command</param>
        public static void AddAddCommand(this Command parent)
        {
            Command c = new ("add", "Add the app to GitOps");
            c.Handler = CommandHandler.Create<AppConfig>(DoAddCommand);
            parent.AddCommand(c);
        }

        // command handler
        public static int DoAddCommand(AppConfig appConfig)
        {
            config = appConfig;

            Console.WriteLine("Add Command");
            Console.WriteLine($"    DryRun   {config.DryRun}");
            Console.WriteLine($"    Verbose  {config.Verbose}");

            return 0;
        }
    }
}
