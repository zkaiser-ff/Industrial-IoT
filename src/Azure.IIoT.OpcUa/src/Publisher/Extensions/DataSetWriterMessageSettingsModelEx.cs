﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Azure.IIoT.OpcUa.Publisher.Models
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Message setting extensions
    /// </summary>
    public static class DataSetWriterMessageSettingsModelEx
    {
        /// <summary>
        /// Clone
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [return: NotNullIfNotNull(nameof(model))]
        public static DataSetWriterMessageSettingsModel? Clone(this DataSetWriterMessageSettingsModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new DataSetWriterMessageSettingsModel
            {
                ConfiguredSize = model.ConfiguredSize,
                DataSetMessageContentMask = model.DataSetMessageContentMask,
                DataSetOffset = model.DataSetOffset,
                NetworkMessageNumber = model.NetworkMessageNumber
            };
        }
    }
}
