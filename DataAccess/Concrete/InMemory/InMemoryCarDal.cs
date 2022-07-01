using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 500, ModelYear = "2020", Description = "Kiralık Mercedes" },
            new Car { Id = 2, BrandId = 2, ColorId = 1, DailyPrice = 600, ModelYear = "2022", Description = "Kiralık Toyota" },
            new Car { Id = 3, BrandId = 1, ColorId = 2, DailyPrice = 800, ModelYear = "2021", Description = "Kiralık BMW" },
            new Car { Id = 4, BrandId = 3, ColorId = 2, DailyPrice = 300, ModelYear = "2019", Description = "Kiralık FIAT" }
        };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id == c.Id);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int BrandId)
        {
            return _cars.Where(c => c.Id == c.Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=>c.Id == c.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
