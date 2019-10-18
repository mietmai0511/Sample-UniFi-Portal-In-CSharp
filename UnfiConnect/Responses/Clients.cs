﻿using Newtonsoft.Json;
using System;

namespace UnfiConnect.Responses
{
    /// <summary>
    /// Details about one client known to UniFi
    /// </summary>
    public class Clients : BaseResponse
    {
        // TODO: Add comments for each property

        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "_is_guest_by_uap")]
        public bool? IsGuestByUap { get; set; }

        [JsonProperty(PropertyName = "_last_seen_by_uap")]
        public long? LastSeenByUapRaw { get; set; }

        [JsonIgnore]
        public DateTime? LastSeenByUap
        {
            get { return LastSeenByUapRaw.HasValue ? (DateTime?)new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(LastSeenByUapRaw.Value).ToLocalTime() : null; }
            set { LastSeenByUapRaw = value.HasValue ? (long?)Math.Floor((value.Value.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds) : null; }
        }

        /// <summary>
        /// Seconds the client already has been connected in its current session
        /// </summary>
        [JsonProperty(PropertyName = "_uptime_by_uap")]
        public long? UptimeByUapRaw { get; set; }

        /// <summary>
        /// TimeSpan returning how long the client has already been connected in its current session
        /// </summary>
        [JsonIgnore]
        public TimeSpan? UptimeByUap
        {
            get { return UptimeByUapRaw.HasValue ? (TimeSpan?)TimeSpan.FromSeconds(UptimeByUapRaw.Value) : null; }
            set { UptimeByUapRaw = value.HasValue ? (long?)value.Value.TotalSeconds : null; }
        }

        /// <summary>
        /// Mac address of the access point to which the client is connected
        /// </summary>
        [JsonProperty(PropertyName = "ap_mac")]
        public string AccessPointMacAddress { get; set; }

        [JsonProperty(PropertyName = "assoc_time")]
        public long? AssociatedTimeRaw { get; set; }

        [JsonIgnore]
        public DateTime? AssociatedTime
        {
            get { return AssociatedTimeRaw.HasValue ? (DateTime?)new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(AssociatedTimeRaw.Value).ToLocalTime() : null; }
            set { AssociatedTimeRaw = value.HasValue ? (long?)Math.Floor((value.Value.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds) : null; }
        }

        /// <summary>
        /// Boolean indicating if the client is authorized on the UniFi network. Only has a meaning when the client is connected to a guest network which requires consent or login first.
        /// </summary>
        [JsonProperty(PropertyName = "authorized")]
        public bool? IsAuthorized { get; set; }

        /// <summary>
        /// String providing information on what authorized this client
        /// </summary>
        [JsonProperty(PropertyName = "authorized_by")]
        public string AuthorizedBy{ get; set; }

        [JsonProperty(PropertyName = "bssid")]
        public string BssId { get; set; }

        [JsonProperty(PropertyName = "bytes-r")]
        public long? BytesReceived { get; set; }

        [JsonProperty(PropertyName = "ccq")]
        public int? Ccq { get; set; }

        /// <summary>
        /// The WiFi channel the client is connected to
        /// </summary>
        [JsonProperty(PropertyName = "channel")]
        public int? Channel { get; set; }

        [JsonProperty(PropertyName = "essid")]
        public string EssId { get; set; }

        /// <summary>
        /// The raw numeric value in Unix epoch time defining when the client was first seen on the UniFi network. Use FirstSeen to get a DateTime of this same value.
        /// </summary>
        [JsonProperty(PropertyName = "first_seen")]
        public long? FirstSeenRaw { get; set; }

        /// <summary>
        /// Date/time indicating when this client was first seen on the UniFi network
        /// </summary>
        [JsonIgnore]
        public DateTime? FirstSeen
        {
            get { return FirstSeenRaw.HasValue ? (DateTime?)new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(FirstSeenRaw.Value).ToLocalTime() : null; }
            set { FirstSeenRaw = value.HasValue ? (long?)Math.Floor((value.Value.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds) : null; }
        }

        /// <summary>
        /// Hostname as provided by the device
        /// </summary>
        [JsonProperty(PropertyName = "hostname")]
        public string Hostname { get; set; }

        /// <summary>
        /// Seconds the device has been idle without sending data through UniFi
        /// </summary>
        [JsonProperty(PropertyName = "idletime")]
        public long? IdleTimeRaw { get; set; }

        /// <summary>
        /// TimeSpan representing the time the device has been idle without sending data through UniFi
        /// </summary>
        [JsonIgnore]
        public TimeSpan? IdleTime
        {
            get { return IdleTimeRaw.HasValue ? (TimeSpan?)TimeSpan.FromSeconds(IdleTimeRaw.Value) : null; }
            set { IdleTimeRaw = value.HasValue ? (long?)value.Value.TotalSeconds : null; }
        }

        /// <summary>
        /// IP Address of the client on the network
        /// </summary>
        [JsonProperty(PropertyName = "ip")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Boolean indicating if the client is logged in through a guest portal
        /// </summary>
        [JsonProperty(PropertyName = "is_guest")]
        public bool? IsGuest { get; set; }

        /// <summary>
        /// Boolean indicating if the client is currently blocked from accessing the UniFi network
        /// </summary>
        [JsonProperty(PropertyName = "blocked")]
        public bool? IsBlocked { get; set; }

        /// <summary>
        /// Boolean indicating if this is a wired client (true) or a client connected through WiFi (false)
        /// </summary>
        [JsonProperty(PropertyName = "is_wired")]
        public bool? IsWired { get; set; }

        /// <summary>
        /// Seconds since January 1, 1970 when this client last communicated with a UniFi device. Use LastSeen for a DateTime representing this value.
        /// </summary>
        [JsonProperty(PropertyName = "last_seen")]
        public long? LastSeenRaw { get; set; }

        /// <summary>
        /// DateTime when this client last communicated with a UniFi device
        /// </summary>
        [JsonIgnore]
        public DateTime? LastSeen
        {
            get { return LastSeenRaw.HasValue ? (DateTime?)new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(LastSeenRaw.Value).ToLocalTime() : null; }
            set { LastSeenRaw = value.HasValue ? (long?)Math.Floor((value.Value.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds) : null; }
        }

        /// <summary>
        /// Seconds since January 1, 1970 when this client last initiated a connection to a UniFi device. Use LatestAssociationTime for a DateTime representing this value.
        /// </summary>
        [JsonProperty(PropertyName = "latest_assoc_time")]
        public long? LatestAssociationTimeRaw { get; set; }

        /// <summary>
        /// DateTime when this client last initiated a connection to a UniFi device
        /// </summary>
        [JsonIgnore]
        public DateTime? LatestAssociationTime
        {
            get { return LatestAssociationTimeRaw.HasValue ? (DateTime?)new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(LatestAssociationTimeRaw.Value).ToLocalTime() : null; }
            set { LatestAssociationTimeRaw = value.HasValue ? (long?)Math.Floor((value.Value.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds) : null; }
        }

        /// <summary>
        /// The MAC Address of the client device
        /// </summary>
        [JsonProperty(PropertyName = "mac")]
        public string MacAddress { get; set; }

        /// <summary>
        /// The friendly name assigned to the device through the Alias option
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string FriendlyName { get; set; }

        [JsonProperty(PropertyName = "noise")]
        public int? Noise { get; set; }

        [JsonProperty(PropertyName = "noted")]
        public bool? IsNoted { get; set; }

        [JsonProperty(PropertyName = "oui")]
        public string Brand { get; set; }

        [JsonProperty(PropertyName = "powersave_enabled")]
        public bool? IsPowersaveEnabled { get; set; }

        [JsonProperty(PropertyName = "qos_policy_applied")]
        public bool? IsQosPolicyApplied { get; set; }

        [JsonProperty(PropertyName = "radio")]
        public string RadioBand { get; set; }

        [JsonProperty(PropertyName = "radio_proto")]
        public string RadioProtocol { get; set; }

        [JsonProperty(PropertyName = "rssi")]
        public int? SignalStrength { get; set; }

        [JsonProperty(PropertyName = "rx_bytes")]
        public long? ReceivedBytesAllTime { get; set; }

        [JsonProperty(PropertyName = "rx_bytes-r")]
        public long? ReceivedBytesSession { get; set; }

        [JsonProperty(PropertyName = "rx_packets")]
        public long? ReceivedPackets { get; set; }

        [JsonProperty(PropertyName = "rx_rate")]
        public long? ReceivedRate { get; set; }

        [JsonProperty(PropertyName = "signal")]
        public long? Signal { get; set; }

        /// <summary>
        /// Seconds since January 1, 1970 when this authorized client becomes valid. Use StartDate for a DateTime representing this value.
        /// </summary>
        [JsonProperty(PropertyName = "start")]
        public long? Start { get; set; }

        /// <summary>
        /// Date and time at which this client will become authorized
        /// </summary>
        public DateTime? StartDate => Start.HasValue ? new DateTime(1970, 1, 1).AddSeconds(Start.Value) : (DateTime?) null;

        /// <summary>
        /// Seconds since January 1, 1970 when this authorized client will no longer be valid. Use EndDate for a DateTime representing this value.
        /// </summary>
        [JsonProperty(PropertyName = "end")]
        public long? End { get; set; }

        /// <summary>
        /// Date and time at which this client will no longer be authorized
        /// </summary>
        public DateTime? EndDate => End.HasValue ? new DateTime(1970, 1, 1).AddSeconds(End.Value) : (DateTime?)null;

        /// <summary>
        /// Identifier of the site in UniFi to which this client is connected
        /// </summary>
        [JsonProperty(PropertyName = "site_id")]
        public string SiteId { get; set; }

        [JsonProperty(PropertyName = "tx_bytes")]
        public long? TransmittedBytesAllTime { get; set; }

        [JsonProperty(PropertyName = "tx_bytes-r")]
        public long? TransmittedBytesSession { get; set; }

        [JsonProperty(PropertyName = "tx_packets")]
        public long? TransmittedPackets { get; set; }

        [JsonProperty(PropertyName = "tx_power")]
        public long? TransmittedPower { get; set; }

        [JsonProperty(PropertyName = "tx_rate")]
        public long? TransmittedRate { get; set; }

        /// <summary>
        /// Total seconds the client has been connected in its current session
        /// </summary>
        [JsonProperty(PropertyName = "uptime")]
        public long? UptimeRaw { get; set; }

        /// <summary>
        /// TimeSpan representing the time the client has been connected in its current session
        /// </summary>
        [JsonIgnore]
        public TimeSpan? Uptime
        {
            get { return UptimeRaw.HasValue ? (TimeSpan?)TimeSpan.FromSeconds(UptimeRaw.Value) : null; }
            set { UptimeRaw = value.HasValue ? (long?)value.Value.TotalSeconds : null; }
        }

        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "vlan")]
        public int? Vlan { get; set; }

        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }

        [JsonProperty(PropertyName = "usergroup_id")]
        public string UserGroupId { get; set; }

        /// <summary>
        /// Returns the friendly name of the client
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FriendlyName ?? Hostname;
        }
    }
}
