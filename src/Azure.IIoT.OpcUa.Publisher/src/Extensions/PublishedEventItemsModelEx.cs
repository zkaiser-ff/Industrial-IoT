﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Azure.IIoT.OpcUa.Publisher.Models
{
    using Azure.IIoT.OpcUa.Publisher.Stack;
    using Azure.IIoT.OpcUa.Publisher.Stack.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Published event items extensions
    /// </summary>
    public static class PublishedEventItemsModelEx
    {
        /// <summary>
        /// Convert to monitored items
        /// </summary>
        /// <param name="eventItems"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IEnumerable<BaseMonitoredItemModel> ToMonitoredItems(
            this PublishedEventItemsModel eventItems, OpcUaSubscriptionOptions options)
        {
            if (eventItems?.PublishedData == null)
            {
                return Enumerable.Empty<BaseMonitoredItemModel>();
            }

            var map = new Dictionary<string, BaseMonitoredItemModel>();
            foreach (var publishedData in eventItems.PublishedData)
            {
                var monitoredItem = publishedData?.ToMonitoredItem(options);
                if (monitoredItem == null)
                {
                    continue;
                }
                map.AddOrUpdate(monitoredItem.Id ?? Guid.NewGuid().ToString(), monitoredItem);
            }
            return map.Values;
        }
    }
}
