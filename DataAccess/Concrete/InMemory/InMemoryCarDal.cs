using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
            new Car{Id=1,BrandId=10,ColorId=100,DailyPrice=500,ModelYear=2000,Description="Mavi Araba" },
            new Car{Id=2,BrandId=10,ColorId=101,DailyPrice=1500,ModelYear=2006,Description="Kırmızı Araba" },
            new Car{Id=3,BrandId=20,ColorId=100,DailyPrice=2000,ModelYear=2015,Description="Mavi Araba" },
            new Car{Id=4,BrandId=20,ColorId=101,DailyPrice=550,ModelYear=2020,Description="Kırmızı Araba" },
            new Car{Id=5,BrandId=30,ColorId=102,DailyPrice=2000,ModelYear=2018,Description="Siyah Araba" },};
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int categoryId)
        {
            return _cars.Where(c=>c.Id==categoryId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate= _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }
    }
}
