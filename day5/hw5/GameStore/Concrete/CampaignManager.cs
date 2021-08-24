using GameStore.Abstract;
using GameStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Concrete
{
    class CampaignManager : ICampaignService
    {
        public void AddCampaign(Campaign campaign)
        {
            Console.WriteLine("Campaign: "+campaign.DiscountPercentage +  " added.");
        }

        public void RemoveCamapign(Campaign campaign)
        {
            Console.WriteLine("Campaign: " + campaign.DiscountPercentage + " removed.");
        }

        public void UpdateCampaign(Campaign campaign)
        {
            Console.WriteLine("Campaign: " + campaign.DiscountPercentage + " updated.");
        }
    }
}
