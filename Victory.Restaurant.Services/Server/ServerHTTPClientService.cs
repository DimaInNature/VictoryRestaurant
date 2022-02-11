using System.Net.NetworkInformation;

namespace Victory.Restaurant.Services.Server;

public class ServerHTTPClientService
{
    public string ServerName { get; private set; }

    public void Configure(string serverName)
    {
        ServerName = serverName;
    }

    public async Task<IPStatus> Ping(int timeout = 10)
    {
        var serverReply = await new Ping()
            .SendPingAsync(hostNameOrAddress: ServerName, timeout: timeout);

        return serverReply.Status;
    }
}
