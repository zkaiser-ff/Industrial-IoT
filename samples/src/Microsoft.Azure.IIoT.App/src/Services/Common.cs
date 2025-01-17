﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.App.Services
{
    using Microsoft.Azure.IIoT.App.Extensions;
    using Microsoft.Azure.IIoT.App.Models;
    using Microsoft.AspNetCore.Components;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UICommon : ComponentBase
    {
        public PagedResult<T> UpdatePage<T>(Func<PagedResult<T>, Task<PagedResult<T>>> getList,
            int page, PagedResult<T> list, ref PagedResult<T> pagedList, int pageLength) where T : class
        {
            var newList = list;
            if (!string.IsNullOrEmpty(list.ContinuationToken) && page > pagedList.PageCount)
            {
                list = Task.Run(async () => await getList(newList).ConfigureAwait(false)).Result;
            }
            pagedList = list.GetPaged(page, pageLength, null);
            return list;
        }

        public void CheckErrorOrEmpty<T>(PagedResult<T> list, ref string errorCssClass, ref string emptyCssClass) where T : class
        {
            if (list.Error != null)
            {
                errorCssClass = "hidden";
            }
            else
            {
                emptyCssClass = list.Results.Count == 0 ? "displayBlock" : "displayNone";
            }
        }

        public string ExtractSecurityPolicy(string policy)
        {
            var sep = policy.LastIndexOf("#", StringComparison.Ordinal);
            if (sep == -1)
            {
                return policy;
            }
            return policy[(sep + 1)..policy.Length];
        }

        public int PageLength { get; set; } = 10;
        public int PageLengthSmall { get; set; } = 4;
        public string None { get; set; } = "(None)";
        public string Spinner { get; set; }
        public string CredentialKey { get; } = "credential";
        public Dictionary<string, string> ApplicationUri { get; set; } = new Dictionary<string, string>();
    }
}
