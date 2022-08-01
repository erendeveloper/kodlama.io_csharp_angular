using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //bool isCarInfoValid = true;
            //string errorMessage = "";
            //if (car.DailyPrice<0)
            //{
            //    errorMessage += "Daily price must be greater than or equal to 0";
            //    isCarInfoValid = false;
            //}
            //if (car.Description.Length<2)
            //{
            //    errorMessage += "Car description must be min 2 characters.";
            //    isCarInfoValid = false;
            //}

            //if(isCarInfoValid)
            //{
            //    _carDal.Add(car);
            //    return new SuccessResult(Messages.ItemAdded);
            //}
            //else
            //{
            //    return new ErrorResult(errorMessage);
            //}

            //ValidationTool.Validate(new CarValidator(),car);

            _carDal.Add(car);
            return new SuccessResult(Messages.ItemAdded);

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
