using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1, BrandId=1, ColorId=1, DailyPrice=10, ModelYear = 2001, Description="Temiz"},
                new Car{CarId=2, BrandId=1, ColorId=1, DailyPrice=10, ModelYear = 2001, Description="Konforlu"},
                new Car{CarId=3, BrandId=2, ColorId=1, DailyPrice=20, ModelYear = 2002, Description="Konforlu lüx"},
                new Car{CarId=4, BrandId=3, ColorId=2, DailyPrice=30, ModelYear = 2003, Description="Üst Segment"},
                new Car{CarId=5, BrandId=3, ColorId=2, DailyPrice=30, ModelYear = 2006, Description="Konforlu Lüx Kamyon"},
                new Car{CarId=6, BrandId=4, ColorId=2, DailyPrice=40, ModelYear = 2007, Description="Konforlu Lüx Otobüs"},
                new Car{CarId=7, BrandId=5, ColorId=3, DailyPrice=50, ModelYear = 2021, Description="Konforlu Lüx otomobil"},
                new Car{CarId=8, BrandId=5, ColorId=3, DailyPrice=50, ModelYear = 2021, Description="Konforlu Lüx Airbagli otomobil"},
                new Car{CarId=9, BrandId=5, ColorId=3, DailyPrice=50, ModelYear = 2021, Description="Konforlu Lüx Klimalı otomobil"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId && p.BrandId == car.BrandId || p.ColorId == p.ColorId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(p => p.DailyPrice > 20 && p.ModelYear > 2003).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;

        }
    }
}
