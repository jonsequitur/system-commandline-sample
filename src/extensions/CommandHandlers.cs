// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace SCL.CommandLine.Extensions
{
    public static class CommandHandlers
    {
        // command handler
        public static int DoAddCommand(AppConfig appConfig)
        {
            PrintConfig("Add Command", appConfig);

            return 0;
        }

        // bootstrap-add handler
        public static int DoBootstrapAddCommand(BootstrapConfig bootstrapConfig)
        {
            PrintBootstrapConfig("Add Command", bootstrapConfig);

            return 0;
        }

        // bootstrap-remove handler
        public static int DoBootstrapRemoveCommand(BootstrapConfig bootstrapConfig)
        {
            PrintBootstrapConfig("Remove Command", bootstrapConfig);

            return 0;
        }

        // command handler
        public static int DoBuildCommand(AppConfig appConfig)
        {
            PrintConfig("Build Command", appConfig);

            return 0;
        }

        // command handler
        public static int DoCheckCommand(AppConfig appConfig)
        {
            PrintConfig("Check Command", appConfig);

            return 0;
        }

        // command handler
        public static int DoConfigUpdate(AppConfig appConfig)
        {
            PrintConfig("Config Update", appConfig);

            return 0;
        }

        // command handler
        public static int DoConfigReset(AppConfig appConfig)
        {
            PrintConfig("Config Reset", appConfig);

            return 0;
        }

        // command handler
        public static int DoInitCommand(AppConfig appConfig)
        {
            PrintConfig("Init Command", appConfig);

            return 0;
        }

        // command handler
        public static int DoListCommand(AppConfig appConfig)
        {
            PrintConfig("List Command", appConfig);

            return 0;
        }

        // command handler
        public static int DoLogsCommand(AppConfig appConfig)
        {
            PrintConfig("Logs Command", appConfig);

            return 0;
        }

        // command handler
        public static int DoNewDotnetCommand(AppConfig appConfig)
        {
            PrintConfig("New Dotnet Command", appConfig);

            return 0;
        }

        // command handler
        public static int DoRemoveCommand(AppConfig appConfig)
        {
            PrintConfig("Remove Command", appConfig);

            return 0;
        }

        // command handler
        public static int DoSyncCommand(AppConfig appConfig)
        {
            PrintConfig("Sync Command", appConfig);

            return 0;
        }

        // for debugging
        private static void PrintConfig(string method, AppConfig config)
        {
            Console.WriteLine(method);
            Console.WriteLine($"    DryRun    {config.DryRun}");
            Console.WriteLine($"    Verbose   {config.Verbose}");
        }

        // for debugging
        private static void PrintBootstrapConfig(string method, BootstrapConfig config)
        {
            Console.WriteLine(method);
            if (config.Services != null && config.Services.Count > 0)
            {
                Console.WriteLine($"    Services  {string.Join(' ', config.Services)}");
            }
            else
            {
                Console.WriteLine("    Services  null");
            }

            Console.WriteLine($"    All       {config.All}");
            Console.WriteLine($"    DryRun    {config.DryRun}");
            Console.WriteLine($"    Verbose   {config.Verbose}");
        }
    }
}
