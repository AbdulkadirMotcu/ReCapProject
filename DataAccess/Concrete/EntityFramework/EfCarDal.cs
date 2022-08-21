using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDemoContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarDemoContext context = new CarDemoContext())
            {
                var result = from c in context.Cars 
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 CarName = c.CarName,
                                 DailyPrice = (double)c.DailyPrice,
                                 Description=c.Description,


                             };
                return result.ToList();
            }
        }
    }
}
