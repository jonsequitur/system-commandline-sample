﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;

namespace SCL.CommandLine.Extensions
{
    /// <summary>
    /// Command handlers for each leaf command
    /// These are very simple examples
    /// The way System.CommandLine handles calling the right handler is simple and elegant
    ///   which allows you to write very clean code and avoid parsing
    /// Another structure option is to include the Add extension and the handler in a "command class"
    ///   that is how we initially implemented it and we decided we liked the "grouping" better
    ///   depending on how complex your handlers are, you may want to use a different approach
    /// Grouping the Add extension, [validation] and handler in a command class also provides some interesting reuse capabilities
    /// </summary>
    public static class CommandHandlers
    {
        /// <summary>
        /// add Command Handler
        /// </summary>
        /// <param name="appConfig">parsed command line in AppConfig</param>
        /// <returns>0 on success</returns>
        public static int DoAddCommand(AppConfig appConfig)
        {
            return PrintConfig("Add Command", appConfig);
        }

        /// <summary>
        /// bootstrap-add Command Handler
        /// </summary>
        /// <param name="bootstrapConfig">parsed command line in BootstrapConfig</param>
        /// <returns>0 on success</returns>
        public static int DoBootstrapAddCommand(BootstrapConfig bootstrapConfig)
        {
            return PrintBootstrapConfig("Add Command", bootstrapConfig);
        }

        /// <summary>
        /// bootstrap-remove Command Handler
        /// </summary>
        /// <param name="bootstrapConfig">parsed command line in BootstrapConfig</param>
        /// <returns>0 on success</returns>
        public static int DoBootstrapRemoveCommand(BootstrapConfig bootstrapConfig)
        {
            return PrintBootstrapConfig("Remove Command", bootstrapConfig);
        }

        /// <summary>
        /// build Command Handler
        /// </summary>
        /// <param name="appConfig">parsed command line in AppConfig</param>
        /// <returns>0 on success</returns>
        public static int DoBuildCommand(AppConfig appConfig)
        {
            return PrintConfig("Build Command", appConfig);
        }

        /// <summary>
        /// check Command Handler
        /// </summary>
        /// <param name="appConfig">parsed command line in AppConfig</param>
        /// <returns>0 on success</returns>
        public static int DoCheckCommand(AppConfig appConfig)
        {
            return PrintConfig("Check Command", appConfig);
        }

        /// <summary>
        /// config-reset Command Handler
        /// </summary>
        /// <param name="appConfig">parsed command line in AppConfig</param>
        /// <returns>0 on success</returns>
        public static int DoConfigReset(AppConfig appConfig)
        {
            return PrintConfig("Config Reset", appConfig);
        }

        /// <summary>
        /// config-update Command Handler
        /// </summary>
        /// <param name="appConfig">parsed command line in AppConfig</param>
        /// <returns>0 on success</returns>
        public static int DoConfigUpdate(AppConfig appConfig)
        {
            return PrintConfig("Config Update", appConfig);
        }

        /// <summary>
        /// init Command Handler
        /// </summary>
        /// <param name="appConfig">parsed command line in AppConfig</param>
        /// <returns>0 on success</returns>
        public static int DoInitCommand(AppConfig appConfig)
        {
            return PrintConfig("Init Command", appConfig);
        }

        /// <summary>
        /// list Command Handler
        /// </summary>
        /// <param name="appConfig">parsed command line in AppConfig</param>
        /// <returns>0 on success</returns>
        public static int DoListCommand(AppConfig appConfig)
        {
            return PrintConfig("List Command", appConfig);
        }

        /// <summary>
        /// logs Command Handler
        /// </summary>
        /// <param name="appConfig">parsed command line in AppConfig</param>
        /// <returns>0 on success</returns>
        public static int DoLogsCommand(AppConfig appConfig)
        {
            return PrintConfig("Logs Command", appConfig);
        }

        /// <summary>
        /// new-dotnet Command Handler
        /// </summary>
        /// <param name="appConfig">parsed command line in AppConfig</param>
        /// <returns>0 on success</returns>
        public static int DoNewDotnetCommand(AppConfig appConfig)
        {
            return PrintConfig("New Dotnet Command", appConfig);
        }

        /// <summary>
        /// remove Command Handler
        /// </summary>
        /// <param name="appConfig">parsed command line in AppConfig</param>
        /// <returns>0 on success</returns>
        public static int DoRemoveCommand(AppConfig appConfig)
        {
            return PrintConfig("Remove Command", appConfig);
        }

        /// <summary>
        /// sync Command Handler
        /// </summary>
        /// <param name="appConfig">parsed command line in AppConfig</param>
        /// <returns>0 on success</returns>
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
