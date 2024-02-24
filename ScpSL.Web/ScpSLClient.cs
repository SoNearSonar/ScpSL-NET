using Newtonsoft.Json;
using ScpSL.Web.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ScpSL.Web
{
    public class ScpSLClient
    {
        private readonly string _northwoodApiUrl = "https://api.scpslgame.com";
        private static HttpClient _httpClient;
        private string _apiKey = string.Empty;

        public uint ID { get; set; }
        public bool AddLastOnline { get; set; }
        public bool AddPlayers { get; set; }
        public bool AddPlayersList { get; set; }
        public bool AddInfo { get; set; }
        public bool AddPastebin { get; set; }
        public bool AddVersion { get; set; }
        public bool AddFlags { get; set; }
        public bool AddNicknames { get; set; }
        public bool AddIsOnline { get; set; }

        public ScpSLClient(string apiKey = "")
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "ScpSL-NET/1.0");

            if (!string.IsNullOrWhiteSpace(apiKey))
            {
                _apiKey = apiKey;
            }
        }

        public async Task<string> GetIPAddress()
        {
            string fullUrl = string.Concat(_northwoodApiUrl, "/ip.php");
            HttpResponseMessage message = await _httpClient.GetAsync(fullUrl);

            if (message.StatusCode == HttpStatusCode.OK)
            {
                return await message.Content.ReadAsStringAsync();
            }

            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        public async Task<ServerInfo> GetServerInfo()
        {
            string resultQuery = ConstructServerQuery(_northwoodApiUrl + "/serverinfo.php");
            HttpResponseMessage message = await _httpClient.GetAsync(resultQuery);

            if (message.StatusCode == HttpStatusCode.OK)
            {
                string contents = await message.Content.ReadAsStringAsync();
                return DeserializeObject<ServerInfo>(contents);
            }

            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        public async Task<ServerInfo> Get3rdPartyServerInfo(string url)
        {
            bool result = Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!result)
            {
                throw new HttpRequestException("Invalid URL provided");
            }

            string resultQuery = ConstructServerQuery(url);
            HttpResponseMessage message = await _httpClient.GetAsync(resultQuery);

            if (message.StatusCode == HttpStatusCode.OK)
            {
                string contents = await message.Content.ReadAsStringAsync();
                return DeserializeObject<ServerInfo>(contents);
            }

            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        public async Task<List<FullServerInfo>> GetFullServerInfo(bool isMinimalSearch = false)
        {
            string resultQuery = ConstructFullServerQuery(_northwoodApiUrl + "/lobbylist.php?format=json", isMinimalSearch);
            HttpResponseMessage message = await _httpClient.GetAsync(resultQuery);

            if (message.StatusCode == HttpStatusCode.OK)
            {
                string contents = await message.Content.ReadAsStringAsync();
                return DeserializeObject<List<FullServerInfo>>(contents);
            }

            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        public async Task<List<FullServerInfo>> Get3rdPartyFullServerInfo(string url)
        {
            bool result = Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!result)
            {
                throw new HttpRequestException("Invalid URL provided");
            }

            HttpResponseMessage message = await _httpClient.GetAsync(url);

            if (message.StatusCode == HttpStatusCode.OK)
            {
                string contents = await message.Content.ReadAsStringAsync();
                return DeserializeObject<List<FullServerInfo>>(contents);
            }

            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        private static T DeserializeObject<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                throw new HttpRequestException("JSON is not in the correct format.");
            }
        }

        private string ConstructFullServerQuery(string url, bool isMinimalSearch)
        {
            StringBuilder sb = new StringBuilder(url);
            sb.Append("&key=");
            sb.Append(_apiKey);

            if (isMinimalSearch)
            {
                sb.Append("&minimal");
            }

            return sb.ToString();
        }

        private string ConstructServerQuery(string url)
        {
            StringBuilder sb = new StringBuilder(url);

            sb.Append("?id=");
            sb.Append(ID);
            sb.Append("&key=");
            sb.Append(_apiKey);
            sb.Append("&lo=");
            sb.Append(AddLastOnline);
            sb.Append("&players=");
            sb.Append(AddPlayers);
            sb.Append("&list=");
            sb.Append(AddPlayersList);
            sb.Append("&info=");
            sb.Append(AddInfo);
            sb.Append("&pastebin=");
            sb.Append(AddPastebin);
            sb.Append("&version=");
            sb.Append(AddVersion);
            sb.Append("&flags=");
            sb.Append(AddFlags);
            sb.Append("&nicknames=");
            sb.Append(AddNicknames);
            sb.Append("&online=");
            sb.Append(AddLastOnline);

            return sb.ToString();
        }
    }
}
