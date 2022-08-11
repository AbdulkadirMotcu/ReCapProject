using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //Brand brand1 = new Brand { BrandId = 4, BrandName="VOLVO"};
            //Brand brand2 = new Brand { BrandId = 5, BrandName="Opel"};
            //Brand brand3 = new Brand { BrandId = 6, BrandName="Toyoto"};

            //brandManager.Add(brand1);
            //brandManager.Add(brand2);
            //brandManager.Add(brand3);

            //brand2.BrandName = "Skoda";
            //brandManager.Update(brand2);

            //brandManager.Delete(brand3);

            ColorManager colorManager = new ColorManager(new EfColorDal());
            //Color color1 = new Color { ColorId = 4, ColorName = "Fildişi" };
            //Color color2 = new Color { ColorId = 5, ColorName = "AQUA" };

            //colorManager.Add(color1);
            //colorManager.Add(color2);

            //UserManager userManager = new UserManager(new EfUserDal());
            //User user1 = new User {Id = 1, FirstName = "Kadir", LastName= "Motcu", Email = "kadirmotcu@gmail.com", Password = "123456" };
            //userManager.Add(user1);

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer1 = new Customer{Id = 1, UserId = 1 ,CompanyName ="asddsa"  };
            customerManager.Add(customer1);

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental1 = new Rental { Id = 1, CarId = 1, CustomerId = 1, RentDate = new DateTime(2022, 07, 02), ReturnDate = new DateTime(2022,07,03) };
            rentalManager.Add(rental1);

            //Console.WriteLine(user1.FirstName);
            



        }

       

    }

    
}
