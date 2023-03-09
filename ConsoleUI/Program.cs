using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            List<Car> cars = carManager.GetAll();

            foreach (var car in cars)
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("Getting car by id: ");
            Console.WriteLine(carManager.GetById(1).Description);

            Console.ReadLine(); 

        }
    }
}
