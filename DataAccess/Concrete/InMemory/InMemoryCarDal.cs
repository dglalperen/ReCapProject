using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars = new List<Car> {
            new Car{ Id = 1,BrandId = 1, ColorId = 1, DailyPrice=250000, Description="Luxury Car", ModelYear=2020},
            new Car{ Id = 2,BrandId = 1, ColorId = 1, DailyPrice=750000, Description="Most expensive Car", ModelYear=2022},
            new Car{ Id = 3,BrandId = 2, ColorId = 2, DailyPrice=50000, Description="A Car for a large family", ModelYear=2017},
            new Car{ Id = 4,BrandId = 3, ColorId = 3, DailyPrice=30000, Description="Budget Car for beginners", ModelYear=2015},
        };


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);

            if(carToDelete == null)
            {
                Console.WriteLine("Car does not exist");
                return;
            }
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

        public Car GetById(int id)
        {
            return _cars.Where(c => c.Id == id).First();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
        }
    }
}
