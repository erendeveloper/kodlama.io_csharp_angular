using Business.Concrete;
using Core.Entities.Concrete;
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
            //AddBrands(brandManager);

            ColorManager colorManager = new ColorManager(new EfColorDal());
            //AddColors(colorManager);

            CarManager carManager = new CarManager(new EfCarDal());
            //AddCars(carManager);

            //ListCarDetails(carManager);

            UserManager userManager = new UserManager(new EfUserDal());
            //AddUsers(userManager);

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            AddCustomers(customerManager);

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            AddRentals(rentalManager);
            ListRentals(rentalManager);

        }

        private static void ListRentals(RentalManager rentalManager)
        {
            var rentals = rentalManager.GetAll();
            foreach (var rental in rentals.Data)
            {
                Console.WriteLine("Id: {0}, CarId: {1}, CustomerId: {2}, RentDate{3}, ReturnDate{4}", rental.Id, rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);
            }
        }

        private static void AddRentals(RentalManager rentalManager)
        {
            Rental rental1 = new Rental { Id = 1, CarId = 1, CustomerId = 1, RentDate = new DateTime(2022, 1, 1), ReturnDate = new DateTime(2022, 1, 2) };
            Rental rental2 = new Rental { Id = 2, CarId = 2, CustomerId = 1, RentDate = new DateTime(2022, 1, 1), ReturnDate = null };
            Rental rental3 = new Rental { Id = 2, CarId = 3, CustomerId = 2, RentDate = new DateTime(2022, 1, 1), ReturnDate = new DateTime(2022, 1, 2) };

            rentalManager.Add(rental1);
            rentalManager.Add(rental2);
            rentalManager.Add(rental3);
        }

        private static void AddCustomers(CustomerManager customerManager)
        {
            Customer customer1 = new Customer { CustomerId = 1, CompanyName = "CompanyName1" };
            Customer customer2 = new Customer { CustomerId = 2, CompanyName = "CompanyName1" };
            Customer customer3 = new Customer { CustomerId = 3, CompanyName = "CompanyName2" };

            customerManager.Add(customer1);
            customerManager.Add(customer2);
            customerManager.Add(customer3);
        }

        private static void AddUsers(UserManager userManager)
        {
            //User user1 = new User { Id = 1, FirstName = "FirstName1", LastName = "LastName1", Email = "email1@email1.com", Password = "password1" };
            //User user2 = new User { Id = 2, FirstName = "FirstName2", LastName = "LastName2", Email = "email2@email2.com", Password = "password2" };
            //User user3 = new User { Id = 3, FirstName = "FirstName3", LastName = "LastName3", Email = "email3@email3.com", Password = "password3" };

            //userManager.Add(user1);
            //userManager.Add(user2);
            //userManager.Add(user3);
        }

        private static void ListCarDetails(CarManager carManager)
        {
            var carDetails = carManager.GetCarDetails();
            foreach (var detail in carDetails.Data)
            {
                Console.WriteLine("Brand name: {0}, Color name: {1}, DailyPrice: {2}", detail.BrandName, detail.ColorName, detail.DailyPrice);
            }
        }

        private static void AddCars(CarManager carManager)
        {
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
        }

        private static void AddColors(ColorManager colorManager)
        {
            Color color1 = new Color { Id = 1, Name = "Green" };
            Color color2 = new Color { Id = 2, Name = "Yellow" };
            Color color3 = new Color { Id = 3, Name = "Purple" };

            colorManager.Add(color1);
            colorManager.Add(color2);
            colorManager.Add(color3);

            colorManager.Delete(color3);

            color2.Name = "Blue";
            colorManager.Update(color2);
        }

        private static void AddBrands(BrandManager brandManager)
        {
            Brand brand1 = new Brand { Id = 1, Name = "Brand1" };
            Brand brand2 = new Brand { Id = 2, Name = "Brand4" };
            Brand brand3 = new Brand { Id = 3, Name = "Brand3" };

            brandManager.Add(brand1);
            brandManager.Add(brand2);
            brandManager.Add(brand3);

            brandManager.Delete(brand3);

            brand2.Name = "Brand2";
            brandManager.Update(brand2);
        }
    }
}
