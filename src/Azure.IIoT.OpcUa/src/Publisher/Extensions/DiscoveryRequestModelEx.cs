// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Azure.IIoT.OpcUa.Publisher.Models
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Discovery request model extensions
    /// </summary>
    public static class DiscoveryRequestModelEx
    {
        /// <summary>
        /// Clone
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [return: NotNullIfNotNull(nameof(model))]
        public static DiscoveryRequestModel? Clone(this DiscoveryRequestModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new DiscoveryRequestModel
            {
                Configuration = model.Configuration.Clone(),
                Discovery = model.Discovery,
                Context = model.Context?.Clone(),
                Id = model.Id
            };
        }
    }
}
