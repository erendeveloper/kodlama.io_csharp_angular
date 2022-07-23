using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Car car)
        {
            bool state = true;
            string errorMessage = "";
            if (!_carCheckService.CheckDailyPrice(car))
            {
                errorMessage += Messages.ItemPriceInvalid;
            }
            if (!_carCheckService.CheckDescription(car))
            {
                errorMessage += Messages.ItemDescriptionInvalid;
            }

            if(state == true)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.ItemAdded);
            }
            else
            {
                return new ErrorResult(errorMessage);
            }
                    
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>
                (
                _carDal.GetAll()
                );
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>
                (
                _carDal.Get(p => p.Id == id)
                ); 
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(
                _carDal.GetCarDetails()
                ); 
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>
                (
                   _carDal.GetAll(p => p.BrandId == id)
                ); 
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>
                (
                _carDal.GetAll(p => p.ColorId == id)
                ); 
        }

        public IResult Update(Car car)
        {         
            _carDal.Update(car);
            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
