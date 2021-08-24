using GameStore.Adapters;
using GameStore.Concrete;
using GameStore.Entities;
using System;

namespace GameStore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Gamer
            GamerManager gamerManager = new GamerManager(new MernisServiceAdapter());

            Gamer gamer = new Gamer();
            gamer.Id = 1;
            gamer.Name = "EREN";
            gamer.Surname = "AYDIN";
            gamer.NationalityId = 01234567890;
            gamer.BirthYear = 2000;
 
            gamerManager.AddGamer(gamer);

            //Game
            GameManager gameManager = new GameManager();

            Game game = new Game();
            game.Id = 1;
            game.GameName = "Maryo";
            game.Price = 100f;

            gameManager.AddGame(game);

            //Campaign
            CampaignManager campaignManager = new CampaignManager();

            Campaign campaign = new Campaign();
            campaign.Id = 1;
            campaign.DiscountPercentage = 10f;          

            campaignManager.AddCampaign(campaign);

            //Sale

            SalesManager salesManager = new SalesManager();

            salesManager.Sell(gamer, game, campaign);

            Console.ReadLine();
        }
    }
}
