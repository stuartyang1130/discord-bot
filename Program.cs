using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

class Program
{
    private DiscordSocketClient _client;

    static async Task Main(string[] args)
    {
        var program = new Program();
        await program.RunBotAsync();
    }
    public async Task RunBotAsync()
    {
        _client = new DiscordSocketClient();
        _client.Log += LogAsync;
        // _client.Ready += ReadyAsync;
        _client.MessageReceived += MessageReceivedAsync;

        await _client.LoginAsync(TokenType.Bot, "YOUR_BOT_TOKEN");
        await _client.StartAsync();

        await Task.Delay(-1);
    }
    private Task LogAsync(LogMessage log)
    {
        Console.WriteLine(log);
        return Task.CompletedTask;
    }
    private async Task MessageReceivedAsync(SocketMessage message)
    {
        if(message.Content.ToLower() == "hello")
        {
            await message.Channel.SendMessageAsync("Hello, Discord!");
        }
    }
}