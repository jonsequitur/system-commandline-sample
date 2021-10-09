// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.Linq;

namespace SCL.CommandLine.Extensions
{
    /// <summary>
    /// System.CommandLine.Command extension
    /// </summary>
    public static class BootstrapCommand
    {
        private static BootstrapConfig config;

        /// <summary>
        /// Extension method to add the BootstrapCommand
        /// </summary>
        /// <param name="parent">System.CommandLine.Command</param>
        public static void AddBootstrapCommand(this Command parent)
        {
            Command bs = new ("bootstrap", "Manage bootstrap services");
            bs.AddAlias("bs");

            Command add = new ("add", "Add bootstrap service");
            add.AddOption(new Option<List<string>>(new string[] { "--services", "-s" }, "bootstrap service(s) to add"));
            add.AddOption(new Option<bool>(new string[] { "--all", "-a" }, "Add all bootstrap services"));
            add.Handler = CommandHandler.Create<BootstrapConfig>(DoAddCommand);
            add.AddValidator(Validate);

            Command rm = new ("remove", "Remove bootstrap service");
            rm.AddAlias("rm");
            rm.AddOption(new Option<List<string>>(new string[] { "--services", "-s" }, "bootstrap service(s) to remove"));
            rm.AddOption(new Option<bool>(new string[] { "--all", "-a" }, "Remove all bootstrap services"));
            rm.Handler = CommandHandler.Create<BootstrapConfig>(DoRemoveCommand);
            rm.AddValidator(Validate);

            // add the commands to the tree
            bs.AddCommand(add);
            bs.AddCommand(rm);
            parent.AddCommand(bs);
        }

        // bootstrap-remove handler
        public static int DoRemoveCommand(BootstrapConfig bootstrapConfig)
        {
            config = bootstrapConfig;

            PrintConfig("Remove Command");

            return 0;
        }

        // bootstrap-add handler
        public static int DoAddCommand(BootstrapConfig bootstrapConfig)
        {
            config = bootstrapConfig;

            PrintConfig("Add Command");

            return 0;
        }

        // validate the parameters
        private static string Validate(CommandResult result)
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

        // for debugging
        private static void PrintConfig(string method)
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
