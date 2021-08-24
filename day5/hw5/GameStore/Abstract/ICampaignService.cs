using GameStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Abstract
{
    interface ICampaignService
    {
        public void AddCampaign(Campaign campaign);
        public void RemoveCamapign(Campaign campaign);
        public void UpdateCampaign(Campaign campaign);
    }
}
