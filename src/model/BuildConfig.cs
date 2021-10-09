// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;

namespace SCL
{
    /// <summary>
    /// Model for commands that use --build-type
    /// System.CommandLine will parse and pass to the handler
    /// </summary>
    public sealed class BuildConfig : AppConfig
    {
        public BuildType BuildType { get; set; }
    }
}
