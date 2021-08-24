using GameStore.Abstract;
using GameStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Concrete
{
    class SalesManager : ISalesService
    {
        public void Sell(Gamer gamer, Game game, Campaign campaign)
        {
            float oldPrice = game.Price;
            float newPrice = oldPrice * (100 - campaign.DiscountPercentage) / 100f;

            Console.WriteLine(gamer.Name + " " + gamer.Surname + " has bought " +
                    game.GameName + " for $" + newPrice + " discounted %" +
                    campaign.DiscountPercentage + ".");
        }
    }
}
