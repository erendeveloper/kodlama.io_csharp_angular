using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarCheckService _carCheckService;

        public CarManager(ICarDal carDal, ICarCheckService carCheckService)
        {
            _carDal = carDal;
            _carCheckService = carCheckService;
        }

        public void Add(Car car)
        {
            bool state = true;
            if (!_carCheckService.CheckDailyPrice(car))
            {
                state = false;
                //throw new Exception("Daily price must be greater than 0.");
                Console.WriteLine("Daily price must be greater than 0.");
            }
            if (!_carCheckService.CheckDescription(car))
            {
                state = false;
                //throw new Exception("Description length must be minimum 2 characters.");
                Console.WriteLine("Description length must be minimum 2 characters.");
            }

            if(state == true)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("The car cannot be added.Fix the car info above.");
            }
                    
            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(p => p.Id == id);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
