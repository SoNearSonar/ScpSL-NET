using Newtonsoft.Json;

namespace ScpSL.Web.Models
{
    public class FullServerInfo
    {
        [JsonProperty("serverId")]
        public int ServerId { get; set; }

        [JsonProperty("accountId")]
        public int AccountId { get; set; }

        [JsonProperty("ip")]
        public string IP { get; set; }

        [JsonProperty("port")]
        public int Port { get; set; }

        [JsonProperty("players")]
        public string Players { get; set; }

        [JsonProperty("distance")]
        public int Distance { get; set; }

        [JsonProperty("info")]
        public string Info { get; set; }

        [JsonProperty("pastebin")]
        public string Pastebin { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("privateBeta")]
        public bool IsPrivateBeta { get; set; }

        [JsonProperty("modded")]
        public bool IsModded { get; set; }

        [JsonProperty("modFlags")]
        public int ModFlags { get; set; }

        [JsonProperty("whitelist")]
        public bool HasWhitelist { get; set; }

        [JsonProperty("isoCode")]
        public string ISOCode { get; set; }

        [JsonProperty("continentCode")]
        public string ContinentCode { get; set; }

        [JsonProperty("latitude")]
        public float Latitude { get; set; }

        [JsonProperty("longitude")]
        public float Longitude { get; set; }

        [JsonProperty("official")]
        public string OfficialTitle { get; set; }

        [JsonProperty("officialCode")]
        public int OfficialCode { get; set; }

        [JsonProperty("displaySection")]
        public int DisplaySection { get; set; }
    }
}
