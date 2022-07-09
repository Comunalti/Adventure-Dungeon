using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Player
{
    public class PlayerManager : LazySingleton<PlayerManager>
    {
        public List<PlayerController> playerControllers = new List<PlayerController>();

        public void AddPlayer(PlayerController playerController)
        {
            playerControllers.Add(playerController);
        }
        public PlayerController GetPlayer()
        {
            var playerController = playerControllers.First();
            return playerController;
        }
    }
}