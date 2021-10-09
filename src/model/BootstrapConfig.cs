// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;

namespace SCL
{
    /// <summary>
    /// Model for bootstrap commands
    /// System.CommandLine will parse and pass to the handler
    /// Repeat this pattern for custom command options
    /// </summary>
    public sealed class BootstrapConfig : AppConfig
    {
        public bool All { get; set; }
        public List<string> Services { get; set; }
    }
}
