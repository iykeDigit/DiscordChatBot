using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;

namespace CSharpBot
{
    public class SuperBot
    {
        public void Initialize(DiscordClient client)
        {
            client.MessageCreated += OnMessageCreated;
        }

        private HashSet<string> _UsersAcknowledged = new();

        private async Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs args)
        {
            if (args.Message.Content.StartsWith("ping"))
            {
                if (_UsersAcknowledged.Contains(args.Author.Username))
                {
                    await client.SendMessageAsync(args.Channel, $"Hey don't bug me {args.Author.Username}");
                }
                else
                {
                    _UsersAcknowledged.Add(args.Author.Username);
                    await client.SendMessageAsync(args.Channel, $"Hey don't ping me {args.Author.Username}");
                }
            }
        }
    }
}
