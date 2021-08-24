using GameStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Abstract
{
    interface ISalesService
    {
        public void Sell(Gamer gamer, Game game, Campaign campaign);
    }
}
