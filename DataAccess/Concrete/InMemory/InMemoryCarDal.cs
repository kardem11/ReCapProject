using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;

using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>();
            {
                new Car { Id = 1, BrandId = 101, ColorId = 251, DailyPrice = 2500, ModelYear = 2022, Description = "Mercedes" };
                new Car { Id = 2, BrandId = 102, ColorId = 252, DailyPrice = 2000, ModelYear = 2021, Description = "Honda" };
                new Car { Id = 3, BrandId = 103, ColorId = 253, DailyPrice = 1800, ModelYear = 2018, Description = "Toyota" };
                new Car { Id = 4, BrandId = 104, ColorId = 254, DailyPrice = 1200, ModelYear = 2017, Description = "Renault" };
                new Car { Id = 5, BrandId = 105, ColorId = 255, DailyPrice = 850, ModelYear = 2015, Description = "Hyundai" };
                new Car { Id = 6, BrandId = 106, ColorId = 256, DailyPrice = 1200, ModelYear = 2018, Description = "Nissan" };
                new Car { Id = 7, BrandId = 107, ColorId = 257, DailyPrice = 1700, ModelYear = 2017, Description = "Mazda" };
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Remove(Car car)
        {
            Car removedToCar = _cars.FirstOrDefault(c => c.Id == car.Id);
        }

        public void Update(Car car)
        {
            Car result = _cars.SingleOrDefault(c => c.Id == car.Id);
            result.ColorId = car.ColorId;
            result.BrandId = car.BrandId;
            result.DailyPrice = car.DailyPrice;
            result.ModelYear = car.ModelYear;
            result.Description = car.Description;

        }

       
    }
}
