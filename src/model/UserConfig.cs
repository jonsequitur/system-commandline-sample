// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;

namespace SCL
{
    /// <summary>
    /// Model for commands that use --user
    /// System.CommandLine will parse and pass to the handler
    /// </summary>
    public sealed class UserConfig : AppConfig
    {
        /// <summary>
        /// Gets or sets the User
        /// </summary>
        public string User { get; set; }
    }
}
