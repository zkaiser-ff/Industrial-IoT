﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.App.Extensions
{
    using global::Azure.IIoT.OpcUa.Publisher.Models;
    using global::Azure.IIoT.OpcUa.Publisher.Service.Sdk;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Handle event
    /// </summary>
    public static class GatewayModelEx
    {
        /// <summary>
        /// Update a list of gateways from a received event
        /// </summary>
        /// <param name="results"></param>
        /// <param name="ev"></param>
        public static void Update(this IList<GatewayModel> results,
            GatewayEventModel ev)
        {
            var gateway = results.FirstOrDefault(e => e.Id == ev.Id);
            if (gateway == null &&
                ev.EventType != GatewayEventType.New)
            {
                return;
            }
            switch (ev.EventType)
            {
                case GatewayEventType.New:
                    if (gateway == null)
                    {
                        // Add if not already in list
                        results.Add(ev.Gateway);
                    }
                    break;
                case GatewayEventType.Updated:
                    ev.Gateway.Patch(gateway);
                    break;
                case GatewayEventType.Deleted:
                    results.Remove(gateway);
                    break;
            }
        }
    }
}
