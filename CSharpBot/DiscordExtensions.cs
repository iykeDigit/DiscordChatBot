using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBot
{
    public static class DiscordExtensions
    {
        private static SuperBot? _TheBot;

        public static DiscordClient AddSuperBot(this DiscordClient client)
        {
            _TheBot = new SuperBot();
            _TheBot.Initialize(client);
            return client;
        }
    }
}
