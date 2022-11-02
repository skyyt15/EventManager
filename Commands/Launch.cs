﻿using CommandSystem;
using EventManager.Games;
using Exiled.API.Features;
using System;

namespace EventManager.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class Launch : ParentCommand
    {
        public Launch() => LoadGeneratedCommands();

        public override string Command { get; } = "launch";

        public override string[] Aliases { get; } =new string[] {};

        public override string Description { get; } = Plugin.avaiable_game;

        public override void LoadGeneratedCommands(){}

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count == 0)
            {
                response = Plugin.avaiable_game;
                return false;
            }
            
            switch (arguments.At(0))
            {
                case "gungame":
                    if (GunGame.IsStarted || Plugin.GameAlreadyEnabled)
                    {
                        response = "error, the game or a another game or Round has already started.";
                        return false;
                    }
                    GunGame.Start(Player.Get((CommandSender)sender));
                    response = "Game launched !";
                    return true;
                default:
                    response = Plugin.avaiable_game;
                    return false;
            }
        }
    }
}