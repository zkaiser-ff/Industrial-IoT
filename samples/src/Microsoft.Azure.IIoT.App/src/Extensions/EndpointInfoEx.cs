﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.App.Extensions
{
    using Microsoft.Azure.IIoT.App.Models;
    using global::Azure.IIoT.OpcUa.Publisher.Models;
    using global::Azure.IIoT.OpcUa.Publisher.Service.Sdk;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Handle event
    /// </summary>
    public static class EndpointInfoEx
    {
        /// <summary>
        /// Update a list of endpoints from a received event
        /// </summary>
        /// <param name="results"></param>
        /// <param name="ev"></param>
        public static void Update(this IList<EndpointInfo> results, EndpointEventModel ev)
        {
            var endpoint = results.FirstOrDefault(e => e.EndpointModel.Registration.Id == ev.Id);
            if (endpoint == null &&
                ev.EventType != EndpointEventType.New)
            {
                return;
            }
            switch (ev.EventType)
            {
                case EndpointEventType.New:
                    if (endpoint == null)
                    {
                        // Add if not already in list
                        results.Insert(0, new EndpointInfo
                        {
                            EndpointModel = ev.Endpoint
                        });
                    }
                    break;
                case EndpointEventType.Enabled:
                case EndpointEventType.Disabled:
                    ev.Endpoint.Patch(endpoint.EndpointModel);
                    break;
                case EndpointEventType.Deleted:
                    results.Remove(endpoint);
                    break;
            }
        }
    }
}
