﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.CommandLine;
using System.CommandLine.Parsing;
using System.IO;
using System.Linq;
using System.Reflection;
using SCL.CommandLine.Extensions;

namespace SCL
{
    /// <summary>
    /// Main application class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point
        /// </summary>
        /// <param name="args">Command Line Parameters</param>
        /// <returns>0 on success</returns>
        public static int Main(string[] args)
        {
            // we all need ascii art :)
            DisplayAsciiArt(args);

            // build the command line args
            RootCommand root = BuildRootCommand();

            // invoke the correct command handler
            // once you understand what this one line of code does, it's really cool!
            // we add a command handler for each of the leaf commands and this automatically calls that handler
            // no switch or if statements!
            // allows for super clean code with no parsing!
            return root.Invoke(args);
        }

        // Build the RootCommand using System.CommandLine
        private static RootCommand BuildRootCommand()
        {
            // this is displayed in the help message
            RootCommand root = new ()
            {
                Name = "scl",
                Description = "System.CommandLine Sample App",
                TreatUnmatchedTokensAsErrors = true,
            };

            // we use extensions to build each command which makes reuse and reorg really fast and easy
            // notice there is no help or version command added
            // --help -h -? and --version are "automatic"
            // --version is controlled by the semver in the project
            //   versionprefix and versionsuffix

            // add the command handlers
            root.AddAddCommand();
            root.AddBootstrapCommand();
            root.AddBuildCommand();
            root.AddCheckCommand();
            root.AddConfigCommand();
            root.AddInitCommand();
            root.AddLogsCommand();
            root.AddRemoveCommand();
            root.AddSyncCommand();

            // add the global options
            // these options are available to all commands and sub commands
            // see AddBootstrapCommand for additional options on specific commands
            root.AddGlobalOption(new Option<bool>(new string[] { "--dry-run", "-d" }, "Validates and displays configuration"));
            root.AddGlobalOption(new Option<bool>(new string[] { "--verbose", "-v" }, "Show verbose output"));

            return root;
        }

        // display Ascii Art
        private static void DisplayAsciiArt(string[] args)
        {
            if (args == null || args.Length == 0 ||
                    (!args.Contains("--version") &&
                        (args.Contains("-h") ||
                            args.Contains("-?") ||
                            args.Contains("--help") ||
                            args.Contains("--dry-run"))))
            {
                // you have to get the path for this to work as a dotnet tool
                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string file = $"{path}/files/ascii-art.txt";

                try
                {
                    if (File.Exists(file))
                    {
                        string txt = File.ReadAllText(file);

                        if (!string.IsNullOrWhiteSpace(txt))
                        {
                            txt = txt.Replace("\r", string.Empty);
                            string[] lines = txt.Split('\n');

                            foreach (string line in lines)
                            {
                                // GEAUX Tigers!
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine(line);
                            }

                            Console.ResetColor();
                        }
                    }
                }
                catch
                {
                    // ignore any errors
                }
            }
        }
    }
}
