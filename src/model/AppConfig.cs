// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace SCL
{
    /// <summary>
    /// BuildType enum used in build command
    /// </summary>
    public enum BuildType
    {
        Debug,
        Release,
    }

    /// <summary>
    /// Model for global command line options
    /// System.CommandLine will parse and pass to the handler
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// Gets or sets a value indicating whether this is a dry run
        /// </summary>
        public bool DryRun { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to provide verbose logging
        /// </summary>
        public bool Verbose { get; set; }
    }
}
