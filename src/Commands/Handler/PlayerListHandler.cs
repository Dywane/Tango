﻿using CSM.Networking;

namespace CSM.Commands.Handler
{
    public class PlayerListHandler : CommandHandler<PlayerListCommand>
    {
        public override byte ID => CommandIds.PlayerListCommand;

        public override void HandleOnClient(PlayerListCommand command)
        {
            MultiplayerManager.Instance.PlayerList.Clear();
            MultiplayerManager.Instance.PlayerList.UnionWith(command.PlayerList);
        }

        public override void HandleOnServer(PlayerListCommand command, Player player)
        {
        }

        public override void OnClientConnect(Player player)
        {
            // Send current player list
            Command.SendToClient(player, new PlayerListCommand { PlayerList = MultiplayerManager.Instance.PlayerList });
        }
    }
}