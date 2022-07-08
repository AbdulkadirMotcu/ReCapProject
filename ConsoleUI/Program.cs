using Business.Concrete;
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

            
            

            

            GetCarDetailsTest(carManager);


        }

        private static void GetCarDetailsTest(CarManager carManager)
        {
            foreach (var cars in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} / {1} / {2} ",cars.BrandName, cars.ColorName, cars.DailyPrice);
            }
        }

    }

    
}
