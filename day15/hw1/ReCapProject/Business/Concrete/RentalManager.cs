using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var carRentalResult = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);
            if (carRentalResult==null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.ItemAdded);
            }
            else
            {
                return new ErrorResult("The car is already rented");
            }           
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>
                (
                _rentalDal.GetAll()
                );
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>
                (
                _rentalDal.Get(r => r.Id == id)
                );
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
