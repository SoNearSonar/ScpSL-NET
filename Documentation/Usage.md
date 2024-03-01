# Using ScpSLAPI-NET
This project is a API wrapper for SCP: Secret Laboratory's server web API with additional support for 3rd party server web API's. It supports the following functions:
- Getting your IP address
- Getting information about your servers
- Getting information about all servers in a lobby list

## Notes
- Getting information about servers requires an API key to be passed in
- Getting information about all servers in a lobby list requires an API key only if you are using Northwood's web API
- Any errors results in a HttpRequestException wrapped in a AggregateException object

Below are examples of calls you can make with this client.

### Getting IP address
```csharp
// Arrange
ScpSLClient client = new ScpSLClient();

// Act
string ipAddress = client.GetIPAddress().Result;

// Assert
Assert.IsNotNull(IPAddress);
```

### Getting server info from Northwood's web API
```csharp
ScpSLClient client = new ScpSLClient("api_key")
{
    ID = 1,
    AddIsOnline = true,
    AddPastebin = true,
    AddVersion = true
};

ServerInfo serverInfo = client.GetServerInfo().Result;

foreach (Server server in serverInfo.Servers)
{
	Console.WriteLine("Server ID: " + server.ID);
	Console.WriteLine("Server port: " + server.Port);
	Console.WriteLine("Server is online? " + server.Online);
	Console.WriteLine("Server was last online: " + server.LastOnline);
	Console.WriteLine("Server version: " + server.Version);
	Console.WriteLine("Server pastebin ID: " + server.Pastebin);
}
```

### Getting lobby list (full server info) from Northwood's web API
```csharp
// Arrange
ScpSLClient client = new ScpSLClient("api_key");

// Act
List<FullServerInfo> servers = client.GetFullServerInfo().Result;

// Assert
Assert.IsNotNull(servers);
Assert.IsTrue(servers.Count != 0);
Assert.IsTrue(servers[0].AccountId != 0);
```

### Getting server info from 3rd party web API
```csharp
// Arrange
ScpSLClient client = new ScpSLClient("api_key")
{
    ID = 1,
    AddIsOnline = true,
    AddPastebin = true,
    AddVersion = true
};

// Act
ServerInfo serverInfo = client.Get3rdPartyServerInfo("https://api.scpsecretlab.pl/serverinfo").Result;

// Assert
Assert.IsNotNull(serverInfo);
Assert.IsTrue(serverInfo.Servers[0].ID != 0);
Assert.IsTrue(serverInfo.Servers[0].Port != 0);
```

### Getting lobby list from 3rd party API
```csharp
// Arrange
ScpSLClient client = new ScpSLClient("api_key");

// Act
List<FullServerInfo> servers = client.Get3rdPartyFullServerInfo("https://api.scpsecretlab.pl/lobbylist").Result;

// Assert
Assert.IsNotNull(servers);
Assert.IsTrue(servers.Count != 0);
Assert.IsTrue(servers[0].AccountId != 0);
```
