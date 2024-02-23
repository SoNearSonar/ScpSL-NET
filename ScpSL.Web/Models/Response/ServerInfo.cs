using Newtonsoft.Json;
using System.Collections.Generic;

namespace ScpSL.Web.Models
{
    public class ServerInfo
    {
        [JsonProperty("Success")]
        public bool Success { get; set; }

        [JsonProperty("Error")]
        public string Error { get; set; }

        [JsonProperty("Servers")]
        public List<Server> Servers { get; set; }

        [JsonProperty("Cooldown")]
        public uint Cooldown { get; set; }
    }
}
