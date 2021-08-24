using GameStore.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Entities
{
    class GamerManager : IGamerService
    {
        IGamerCheckService _IGamercheckService;

        public GamerManager(IGamerCheckService iGamercheckService)
        {
            _IGamercheckService = iGamercheckService;
        }

        public void AddGamer(Gamer gamer)
        {
            if (_IGamercheckService.CheckIfRealPerson(gamer))
                Console.WriteLine("Gamer " + gamer.Name + " " + gamer.Surname + " added.");
            else
                Console.WriteLine("Gamer " + gamer.Name + " " + gamer.Surname + "is not true person");
        }
        public void RemoveGamer(Gamer gamer)
        {
            Console.WriteLine("Gamer " + gamer.Name + " " + gamer.Surname + " removed.");
        }

        public void UpdateGamer(Gamer gamer)
        {
            Console.WriteLine("Gamer " + gamer.Name + " " + gamer.Surname + " updated.");
        }
    }
}
