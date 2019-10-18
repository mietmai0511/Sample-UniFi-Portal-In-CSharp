﻿using Newtonsoft.Json;

namespace UnfiConnect.Responses
{
    /// <summary>
    /// Metadata received from the UniFi Controller
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// The result code indicating the successfulness of the request
        /// </summary>
        [JsonProperty(PropertyName = "rc")]
        public string ResultCode { get; set; }
    }
}
