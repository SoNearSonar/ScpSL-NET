using Newtonsoft.Json;
using System.Collections.Generic;

namespace ScpSL.Web.Models
{
    public class Server
    {
        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("Port")]
        public int Port { get; set; }

        [JsonProperty("Online")]
        public bool Online { get; set; }

        [JsonProperty("LastOnline")]
        public string LastOnline { get; set; }

        [JsonProperty("Players")]
        public string Players { get; set; }

        [JsonProperty("PlayersList")]
        public List<string> PlayersList { get; set; }

        [JsonProperty("Info")]
        public string Info { get; set; }

        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("Pastebin")]
        public string Pastebin { get; set; }

        [JsonProperty("FF")]
        public bool HasFriendlyFire { get; set; }

        [JsonProperty("WL")]
        public bool Whitelist { get; set; }

        [JsonProperty("Modded")]
        public string IsModded { get; set; }

        [JsonProperty("Mods")]
        public int ModsCount { get; set; }

        [JsonProperty("Suppress")]
        public bool IsHiddenFromList { get; set; }

        [JsonProperty("AutoSuppress")]
        public bool IsHiddenAutomatically { get; set; }
    }
}
