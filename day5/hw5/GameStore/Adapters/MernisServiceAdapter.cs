using GameStore.Abstract;
using GameStore.Entities;
using MernisServiceReference;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Adapters
{
    class MernisServiceAdapter : IGamerCheckService
    {
        public bool CheckIfRealPerson(Gamer gamer)
        {
            //KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);

            //return client.TCKimlikNoDogrulaAsync(
            //    //new TCKimlikNoDogrulaRequest(new TCKimlikNoDogrulaRequestBody(
            //        gamer.NationalityId,
            //        gamer.Name.ToUpper(),
            //        gamer.Surname.ToUpper(),
            //        gamer.BirthYear
            //        //)//)
            //    ).Result.Body.TCKimlikNoDogrulaResult;

            return true; //fake simulator
        }
    }
}
