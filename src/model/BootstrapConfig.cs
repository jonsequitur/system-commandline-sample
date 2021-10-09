// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;

namespace SCL
{
    public sealed class BootstrapConfig : AppConfig
    {
        public bool All { get; set; }
        public List<string> Services { get; set; }
    }
}
