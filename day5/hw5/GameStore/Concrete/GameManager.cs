using GameStore.Abstract;
using GameStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Concrete
{
    class GameManager : IGameService
    {
        public void AddGame(Game game)
        {
            Console.WriteLine("Game " + game.GameName + " added.");
        }

        public void RemoveGame(Game game)
        {
            Console.WriteLine("Game " + game.GameName + " removed.");
        }

        public void UpdateGame(Game game)
        {
            Console.WriteLine("Game " + game.GameName + " updated.");
        }
    }
}
