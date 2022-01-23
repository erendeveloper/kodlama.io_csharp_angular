using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarCheckManager : ICarCheckService
    {
        public bool CheckDailyPrice(Car car)
        {
            if(car.DailyPrice > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckDescription(Car car)
        {
            if (car.Description.Length >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
