using GameStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Abstract
{
    interface IGameService
    {
        public void AddGame(Game game);
        public void RemoveGame(Game game);
        public void UpdateGame(Game game);
    }
}
