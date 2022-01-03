using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new  InMemoryCarDal());

            carManager.Add(new Car { Id = 5, BrandId = 3, ColorId = 2, DailyPrice = 30, Description = "Well", ModelYear = 2015 });
            carManager.Add(new Car { Id = 6, BrandId = 1, ColorId = 1, DailyPrice = 30, Description = "Used", ModelYear = 2020 });
            carManager.Update(new Car { Id = 5, BrandId = 2, ColorId = 2, DailyPrice = 30, Description = "Well", ModelYear = 2015 });
            carManager.Delete(new Car { Id = 6, BrandId = 1, ColorId = 1, DailyPrice = 30, Description = "Used", ModelYear = 2020 });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car id:" + car.Id + ", " +
                                  "Brand id:" + car.BrandId + ", " +
                                  "Color id:" + car.ColorId + ", " +
                                  "Daily price:" + car.DailyPrice + ", " +
                                  "Description:" + car.Description + ", " +
                                  "Model Year:" + car.ModelYear + ", "
                                  );
            }
        }
    }
}
