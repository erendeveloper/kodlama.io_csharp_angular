using GameStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Abstract
{
    interface IGamerService
    {
        public void AddGamer(Gamer gamer);
        public void RemoveGamer(Gamer gamer);
        public void UpdateGamer(Gamer gamer);
    }
}
