﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.Linq;

namespace SCL.CommandLine.Extensions
{
    /// <summary>
    /// Extension methods to add commands to system.commandline.command
    /// Called from BuildRootCommand
    /// AddBootstrapCommand is the most complex
    /// </summary>
    public static class CommandAdders
    {
        /// <summary>
        /// Extension method to add the add command
        /// We use this as an example of the EnvVarOptions extension which reads options from env vars as well as command line
        /// </summary>
        /// <param name="parent">System.CommandLine.Command</param>
        public static void AddAddCommand(this Command parent)
        {
            Command c = new ("add", "Add the app to GitOps");
            parent.AddCommand(c);

            // note we are using UserConfig so we can pick up the option we add below
            c.Handler = CommandHandler.Create<UserConfig>(CommandHandlers.DoAddCommand);

            // loading from env var using the EnvVarOptions extension
            //   this will pickup the user from the env vars
            //     you can override by specifying on the command line
            //   by using aliases, we can support all 3 options
            //     --user works for Linux / Mac env var
            //     --username works for Windows env var
            //     -u is the short option for convenience
            // imagine the code you didn't have to write ...
            c.AddOption(EnvVarOptions.AddOption(new string[] { "--user", "--username", "-u" }, "User name", string.Empty));
        }

        /// <summary>
        /// Extension method to add the bootstrap command
        /// </summary>
        /// <param name="parent">System.CommandLine.Command</param>
        public static void AddBootstrapCommand(this Command parent)
        {
            Command bs = new ("bootstrap", "Manage bootstrap services");

            // alias because it's easier to type
            bs.AddAlias("bs");

            Command add = new ("add", "Add bootstrap service");
            add.Handler = CommandHandler.Create<BootstrapConfig>(CommandHandlers.DoBootstrapAddCommand);

            // these options will only be available to this command
            // we could add as global options to the parent command
            // I chose to do it this way to get the custom description
            // Note that our handler uses a different model for the command
            add.AddOption(new Option<List<string>>(new string[] { "--services", "-s" }, "bootstrap service(s) to add"));
            add.AddOption(new Option<bool>(new string[] { "--all", "-a" }, "Add all bootstrap services"));

            // command validator to make sure -s or -a (but not both) are provided
            add.AddValidator(ValidateBootstrapCommand);

            Command rm = new ("remove", "Remove bootstrap service");
            rm.AddAlias("rm");
            rm.Handler = CommandHandler.Create<BootstrapConfig>(CommandHandlers.DoBootstrapRemoveCommand);
            rm.AddOption(new Option<List<string>>(new string[] { "--services", "-s" }, "bootstrap service(s) to remove"));
            rm.AddOption(new Option<bool>(new string[] { "--all", "-a" }, "Remove all bootstrap services"));
            rm.AddValidator(ValidateBootstrapCommand);

            // add the commands to the tree
            bs.AddCommand(add);
            bs.AddCommand(rm);
            parent.AddCommand(bs);
        }

        /// <summary>
        /// Extension method to add the build command
        /// </summary>
        /// <param name="parent">System.CommandLine.Command</param>
        public static void AddBuildCommand(this Command parent)
        {
            Command c = new ("build", "Build the app");
            c.Handler = CommandHandler.Create<AppConfig>(CommandHandlers.DoBuildCommand);
            parent.AddCommand(c);
        }

        /// <summary>
        /// Extension method to add the check command
        /// </summary>
        /// <param name="parent">System.CommandLine.Command</param>
        public static void AddCheckCommand(this Command parent)
        {
            Command c = new ("check", "Check the app endpoint (if configured)");
            c.Handler = CommandHandler.Create<AppConfig>(CommandHandlers.DoCheckCommand);
            parent.AddCommand(c);
        }

        /// <summary>
        /// Extension method to add the config command
        /// </summary>
        /// <param name="parent">System.CommandLine.Command</param>
        public static void AddConfigCommand(this Command parent)
        {
            Command cfg = new ("config", "Manage KubeApps configuration");

            Command c = new ("reset", "Reset config files to default");
            c.Handler = CommandHandler.Create<AppConfig>(CommandHandlers.DoConfigReset);
            cfg.AddCommand(c);

            c = new ("update", "Get the latest config files");
            c.Handler = CommandHandler.Create<AppConfig>(CommandHandlers.DoConfigUpdate);
            cfg.AddCommand(c);

            parent.AddCommand(cfg);
        }

        /// <summary>
        /// Extension method to add the init command
        /// </summary>
        /// <param name="parent">System.CommandLine.Command</param>
        public static void AddInitCommand(this Command parent)
        {
            Command c = new ("init", "Initialize KubeApps");
            c.Handler = CommandHandler.Create<AppConfig>(CommandHandlers.DoInitCommand);
            parent.AddCommand(c);
        }

        /// <summary>
        /// Extension method to add the list command
        /// </summary>
        /// <param name="parent">System.CommandLine.Command</param>
        public static void AddListCommand(this Command parent)
        {
            Command c = new ("list", "List the apps running in Kubernetes");
            c.AddAlias("ls");
            c.Handler = CommandHandler.Create<AppConfig>(CommandHandlers.DoListCommand);
            parent.AddCommand(c);
        }

        /// <summary>
        /// Extension method to add the logs command
        /// </summary>
        /// <param name="parent">System.CommandLine.Command</param>
        public static void AddLogsCommand(this Command parent)
        {
            Command c = new ("logs", "Get the Kubernetes app logs");
            c.Handler = CommandHandler.Create<AppConfig>(CommandHandlers.DoLogsCommand);
            parent.AddCommand(c);
        }

        /// <summary>
        /// Extension method to add the new command
        /// </summary>
        /// <param name="parent">System.CommandLine.Command</param>
        public static void AddNewCommand(this Command parent)
        {
            Command dotnet = new ("dotnet", "Create a new Dotnet WebAPI app");
            dotnet.Handler = CommandHandler.Create<AppConfig>(CommandHandlers.DoNewDotnetCommand);

            Command appNew = new ("new", "Create a new app");

            appNew.AddCommand(dotnet);
            parent.AddCommand(appNew);
        }

        /// <summary>
        /// Extension method to add the remove command
        /// </summary>
        /// <param name="parent">System.CommandLine.Command</param>
        public static void AddRemoveCommand(this Command parent)
        {
            Command c = new ("remove", "Remove app from GitOps");
            c.AddAlias("rm");
            c.Handler = CommandHandler.Create<AppConfig>(CommandHandlers.DoRemoveCommand);
            parent.AddCommand(c);
        }

        /// <summary>
        /// Extension method to add the sync command
        /// </summary>
        /// <param name="parent">System.CommandLine.Command</param>
        public static void AddSyncCommand(this Command parent)
        {
            Command c = new ("sync", "Sync any GitOps changes");
            c.Handler = CommandHandler.Create<AppConfig>(CommandHandlers.DoSyncCommand);
            parent.AddCommand(c);
        }

        // validate the parameters
        private static string ValidateBootstrapCommand(CommandResult result)
        {
            string msg = string.Empty;

            try
            {
                // get the values to validate
                List<string> services = result.Children.FirstOrDefault(c => c.Symbol.Name == "services") is OptionResult svcRes ? svcRes.GetValueOrDefault<List<string>>() : null;
                bool all = result.Children.FirstOrDefault(c => c.Symbol.Name == "all") is OptionResult allRes && allRes.GetValueOrDefault<bool>();

                if (services != null && services.Count == 0)
                {
                    services = null;
                }

                if (!all && services == null)
                {
                    msg += "--services or --all must be specified";
                }

                if (all && services != null)
                {
                    msg += "--services and --all cannot be combined";
                }
            }
            catch
            {
                // system.commandline will catch and display parse exceptions
            }

            // return error message(s) or string.empty
            return msg;
        }
    }
}
