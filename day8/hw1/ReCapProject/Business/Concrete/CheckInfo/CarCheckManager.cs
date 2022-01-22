using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarCheckManager
    {
        private Car car;
        public bool State { get; set; }
        public String Message { get; set; }

        public CarCheckManager(Car car)
        {
            this.car = car;

            CheckInfo();
        }
        
        private void CheckInfo()
        {
            Message = "";
            State = true;
            if (!CheckDailyPrice())
            {
                State = false;
            }
            if (!CheckDescription())
            {
                State = false;
            }
        }

        private bool CheckDailyPrice()
        {
            if(car.DailyPrice > 0)
            {
                return true;
            }
            else
            {
                Message += "Daily price must be greater than 0.\n";
                return false;
            }
        }
        private bool CheckDescription()
        {
            if (car.Description.Length >= 2)
            {
                return true;
            }
            else
            {
                Message += "Description length must be minimum 2 characters.\n";
                return false;
            }
        }
    }
}
