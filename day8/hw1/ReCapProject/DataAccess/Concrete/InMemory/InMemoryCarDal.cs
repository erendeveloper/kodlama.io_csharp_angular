using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
               new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=10, Description="Bad", ModelYear=1990},
               new Car{Id=2, BrandId=1, ColorId=2, DailyPrice=15, Description="Good", ModelYear=2000},
               new Car{Id=3, BrandId=2, ColorId=1, DailyPrice=20, Description="Damaged", ModelYear=2005},
               new Car{Id=4, BrandId=2, ColorId=3, DailyPrice=25, Description="Nice", ModelYear=2010},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToupdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToupdate.BrandId = car.BrandId;
            carToupdate.ColorId = car.ColorId;
            carToupdate.DailyPrice = car.DailyPrice;
            carToupdate.Description = car.Description;
            carToupdate.ModelYear = car.ModelYear;
        }
    }
}
