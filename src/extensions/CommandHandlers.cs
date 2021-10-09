// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace SCL.CommandLine.Extensions
{
    public static class CommandHandlers
    {
        // add command handler
        public static int DoAddCommand(AppConfig appConfig)
        {
            return PrintConfig("Add Command", appConfig); 
        }

        // bootstrap-add handler
        public static int DoBootstrapAddCommand(BootstrapConfig bootstrapConfig)
        {
            return PrintBootstrapConfig("Add Command", bootstrapConfig);
        }

        // bootstrap-remove handler
        public static int DoBootstrapRemoveCommand(BootstrapConfig bootstrapConfig)
        {
            return PrintBootstrapConfig ("Remove Command", bootstrapConfig);
        }

        // build command handler
        public static int DoBuildCommand(AppConfig appConfig)
        {
            return PrintConfig("Build Command", appConfig); 
        }

        // check command handler
        public static int DoCheckCommand(AppConfig appConfig)
        {
            return PrintConfig("Check Command", appConfig); 
        }

        // config-reset command handler
        public static int DoConfigReset(AppConfig appConfig)
        {
            return PrintConfig("Config Reset", appConfig);
        }

        // config-update command handler
        public static int DoConfigUpdate(AppConfig appConfig)
        {
            return PrintConfig("Config Update", appConfig); 
        }

        // init command handler
        public static int DoInitCommand(AppConfig appConfig)
        {
            return PrintConfig("Init Command", appConfig); 
        }

        // list command handler
        public static int DoListCommand(AppConfig appConfig)
        {
            return PrintConfig("List Command", appConfig);
        }

        // logs command handler
        public static int DoLogsCommand(AppConfig appConfig)
        {
            return PrintConfig("Logs Command", appConfig); 
        }

        // new-dotnet command handler
        public static int DoNewDotnetCommand(AppConfig appConfig)
        {
            return PrintConfig("New Dotnet Command", appConfig); 
        }

        // remove command handler
        public static int DoRemoveCommand(AppConfig appConfig)
        {
            return PrintConfig("Remove Command", appConfig);
        }

        // sync command handler
        public static int DoSyncCommand(AppConfig appConfig)
        {
            return PrintConfig("Sync Command", appConfig);
        }

        // for debugging
        private static int PrintConfig(string method, AppConfig config)
        {
            Console.WriteLine(method);
            Console.WriteLine($"    DryRun    {config.DryRun}");
            Console.WriteLine($"    Verbose   {config.Verbose}");

            return 0;
        }

        // for debugging
        private static int PrintBootstrapConfig(string method, BootstrapConfig config)
        {
            PrintConfig(method, config);

            if (config.Services != null && config.Services.Count > 0)
            {
                Console.WriteLine($"    Services  {string.Join(' ', config.Services)}");
            }
            else
            {
                Console.WriteLine("    Services  null");
            }

            Console.WriteLine($"    All       {config.All}");

            return 0;
        }
    }
}
