//Create a discord client

using CSharpBot;
using DSharpPlus;
using Microsoft.Extensions.Configuration;

var source = new CancellationTokenSource();

var config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", true)
                            .AddUserSecrets(typeof(Program).Assembly, true)
                            .Build();   

var client = new DiscordClient(new DiscordConfiguration
{
    Token = config["discordtoken"],
    TokenType = TokenType.Bot
});

//define behaviours
client.AddSuperBot();

var token = source.Token;
await client.ConnectAsync();

source.Cancel();

while (!token.IsCancellationRequested)
{
    await Task.Delay(100);
}

await Task.Delay(-1);