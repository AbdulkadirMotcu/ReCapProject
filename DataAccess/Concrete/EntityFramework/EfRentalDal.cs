﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarDemoContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (var context = new CarDemoContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join u in context.Users on cu.UserId equals u.Id
                             join b in context.Brands on c.BrandId equals b.BrandId
                             select new RentalDetailDto
                             {
                                 BrandName = b.BrandName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();


            }
        }
    }
}
