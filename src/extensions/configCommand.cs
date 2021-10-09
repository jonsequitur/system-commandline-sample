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
    public static class ConfigCommand
    {
        private static AppConfig config;

        /// <summary>
        /// Extension method to add the command
        /// </summary>
        /// <param name="parent">System.CommandLine.Command</param>
        public static void AddConfigCommand(this Command parent)
        {
            Command cfg = new ("config", "Manage KubeApps configuration");

            Command c = new ("reset", "Reset config files to default");
            c.Handler = CommandHandler.Create<AppConfig>(DoConfigReset);
            cfg.AddCommand(c);

            c = new ("update", "Get the latest config files");
            c.Handler = CommandHandler.Create<AppConfig>(DoConfigUpdate);
            cfg.AddCommand(c);

            parent.AddCommand(cfg);
        }

        // command handler
        private static int DoConfigUpdate(AppConfig appConfig)
        {
            config = appConfig;

            PrintConfig("Config Update");

            return 0;
        }

        // command handler
        private static int DoConfigReset(AppConfig config)
        {
            ConfigCommand.config = config;

            PrintConfig("Config Reset");

            return 0;
        }

        // debug results
        private static void PrintConfig(string method)
        {
            Console.WriteLine(method);
            Console.WriteLine($"    DryRun   {config.DryRun}");
            Console.WriteLine($"    Verbose  {config.Verbose}");
        }
    }
}
