// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace SCL
{
    /// <summary>
    /// Model for global command line options
    /// System.CommandLine will parse and pass to the handler
    /// </summary>
    public class AppConfig
    {
        public bool DryRun { get; set; }
        public bool Verbose { get; set; }
    }
}
