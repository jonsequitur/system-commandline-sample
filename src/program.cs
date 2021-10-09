// Copyright (c) Microsoft Corporation. All rights reserved.
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
            // run help if no params passed
            if (args == null || args.Length == 0)
            {
                args = new string[] { "--help" };
            }

            DisplayAsciiArt(args);

            // build the command line args
            RootCommand root = BuildRootCommand();

            // run the app
            return root.Invoke(args);
        }

        // Build the RootCommand using System.CommandLine
        private static RootCommand BuildRootCommand()
        {
            RootCommand root = new ()
            {
                Name = "scl",
                Description = "System.CommandLine Sample App",
                TreatUnmatchedTokensAsErrors = true,
            };

            // add the command handlers
            root.AddAddCommand();
            root.AddBootstrapCommand();
            root.AddBuildCommand();
            root.AddCheckCommand();
            root.AddConfigCommand();
            root.AddInitCommand();
            root.AddListCommand();
            root.AddLogsCommand();
            root.AddNewCommand();
            root.AddRemoveCommand();
            root.AddSyncCommand();

            // add the global options
            root.AddGlobalOption(new Option<bool>(new string[] { "--dry-run", "-d" }, "Validates and displays configuration"));
            root.AddGlobalOption(new Option<bool>(new string[] { "--verbose", "-v" }, "Show verbose output"));

            return root;
        }

        // display Ascii Art
        private static void DisplayAsciiArt(string[] args)
        {
            if (args != null)
            {
                if (!args.Contains("--version") &&
                    (args.Contains("-h") ||
                    args.Contains("--help") ||
                    args.Contains("--dry-run")))
                {
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
}
