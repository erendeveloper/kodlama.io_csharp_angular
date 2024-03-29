﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars

                             join b in context.Brands
                             on c.BrandId equals b.Id

                             join cl in context.Colors
                             on c.ColorId equals cl.Id

                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 DailyPrice = (decimal)(long)c.DailyPrice
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars

                             join b in context.Brands
                             on c.BrandId equals b.Id


                             join cl in context.Colors
                             on c.ColorId equals cl.Id

                             where b.Id == id

                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 DailyPrice = (decimal)(long)c.DailyPrice
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars

                             join b in context.Brands
                             on c.BrandId equals b.Id


                             join cl in context.Colors
                             on c.ColorId equals cl.Id

                             where cl.Id == id

                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 DailyPrice = (decimal)(long)c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
