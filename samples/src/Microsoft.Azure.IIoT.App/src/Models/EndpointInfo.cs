﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.App.Models
{
    using global::Azure.IIoT.OpcUa.Publisher.Models;

    /// <summary>
    /// Endpoint info wrapper
    /// </summary>
    public class EndpointInfo
    {
        /// <summary>
        /// Model
        /// </summary>
        public EndpointInfoModel EndpointModel { get; set; }
    }
}
