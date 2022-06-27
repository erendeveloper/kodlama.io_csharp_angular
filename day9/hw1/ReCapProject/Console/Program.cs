using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand1 = new Brand { Id = 1, Name = "Brand1" };
            Brand brand2 = new Brand { Id = 2, Name = "Brand4" };
            Brand brand3 = new Brand { Id = 3, Name = "Brand3" };

            brandManager.Add(brand1);
            brandManager.Add(brand2);
            brandManager.Add(brand3);

            brandManager.Delete(brand3);

            brand2.Name = "Brand2";
            brandManager.Update(brand2);
            

            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color1 = new Color {Id=1, Name="Green"};
            Color color2 = new Color { Id = 2, Name = "Yellow" };
            Color color3 = new Color { Id = 3, Name = "Purple" };

            colorManager.Add(color1);
            colorManager.Add(color2);
            colorManager.Add(color3);

            colorManager.Delete(color3);

            color2.Name = "Blue";
            colorManager.Update(color2);


            CarManager carManager = new CarManager(new EfCarDal(), new CarCheckManager());

            Car car1 = new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 10, Description = "car1", ModelYear = 2000 };
            Car car2 = new Car { Id = 2, BrandId = 1, ColorId = 2, DailyPrice = 20, Description = "car2", ModelYear = 2001 };
            Car car3 = new Car { Id = 3, BrandId = 2, ColorId = 1, DailyPrice = 30, Description = "car3", ModelYear = 2002 };
            Car car4 = new Car { Id = 4, BrandId = 2, ColorId = 2, DailyPrice = 40, Description = "car4", ModelYear = 2005 };
            Car car5 = new Car { Id = 5, BrandId = 1, ColorId = 1, DailyPrice = 10, Description = "car4", ModelYear = 2010 };

            carManager.Add(car1);
            carManager.Add(car2);
            carManager.Add(car3);
            carManager.Add(car4);
            carManager.Add(car5);

            carManager.Delete(car5);

            car4.ModelYear = 2004;
            carManager.Update(car4);

            //List car details
            var carDetails = carManager.GetCarDetails();
            foreach (var detail in carDetails)
            {
                Console.WriteLine("Brand name: {0}, Color name: {1}, DailyPrice: {2}",detail.BrandName,detail.ColorName,detail.DailyPrice);
            }
        }
    }
}
