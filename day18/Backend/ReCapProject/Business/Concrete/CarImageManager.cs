﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimitExceed(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = _fileHelper.Upload(file, Paths.ImagesRoot);
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(Paths.ImagesRoot + carImage.ImagePath);

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>
                (
                _carImageDal.GetAll()
                );
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = BusinessRules.Run(checkIfAnyCarImageExists(carId));
            if (result != null)
            {
                List<CarImage> carImage = new List<CarImage>();
                carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = Paths.DefaultCarImagePath });
                return new ErrorDataResult<List<CarImage>>(carImage);
            }

            return new SuccessDataResult<List<CarImage>>
                (
                _carImageDal.GetAll(c => c.CarId == carId)
                );
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>
                (
                _carImageDal.Get(c => c.Id == id)
                );
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, Paths.ImagesRoot + carImage.ImagePath, Paths.ImagesRoot);

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ItemUpdated);
        }

        private IResult CheckIfCarImageLimitExceed(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count();
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceed);
            }
            return new SuccessResult();
        }

        private IResult checkIfAnyCarImageExists(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
