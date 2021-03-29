using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars; //Global değişken
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{CarId=1, BrandId=1, ColorId=5, ModelYear=2014, DailyPrice=400, Description="Comfortable"},
            new Car{CarId=2, BrandId=1, ColorId=2, ModelYear=2016, DailyPrice=530, Description="Lounge"},
            new Car{CarId=3, BrandId=3, ColorId=1, ModelYear=2015, DailyPrice=260, Description="Relax"},
            new Car{CarId=4, BrandId=2, ColorId=1, ModelYear=2005, DailyPrice=360, Description="Active"},
            new Car{CarId=5, BrandId=4, ColorId=1, ModelYear=2020, DailyPrice=545, Description="Dynamic"},

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            //LINQ : (Language Integrated Query) kullanırız.
            // =>  : Lambda işaretidir
            // _cars.Remove(car); Referans tip bu şekilde silinmez.

            Car carToDelete = _cars.SingleOrDefault(c=>c.CarId == car.CarId);

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
            return _cars.Where(c => c.BrandId == Id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car) //Ekrandan gelen data
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
