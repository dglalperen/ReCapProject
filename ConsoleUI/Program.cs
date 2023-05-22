using Business.Abstract;
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
            CarTestCRUD();

            //BrandTestCRUD();

            Console.ReadLine();

        }

        private static void UserTestCRUD()
        {

        }


        private static void CarTestCRUD()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //Console.WriteLine("CREATE CAR");
            //carManager.Add(new Car()
            //{
            //    Name = "C63 AMG",
            //    DailyPrice = 50000,
            //    Description = "Nice Car",
            //    ModelYear = 2020
            //});

            Console.WriteLine("Reading Car Details");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("-------------");
                Console.WriteLine(car.CarName);
                Console.WriteLine(car.ColorName);
                Console.WriteLine(car.BrandName);
                Console.WriteLine(car.DailyPrice);
                Console.WriteLine("-------------");
            }

            //Console.WriteLine("UPDATE CAR");
            //Car updatedCar = new Car()
            //{
            //    Id = 2,
            //    Name = "C63 AMG",
            //    DailyPrice = 70000,
            //    Description = "Updated",
            //    ModelYear = 2021
            //};
            //carManager.Update(updatedCar);


            //Console.WriteLine("DELETE CAR");
            //Car deletedCar = new Car()
            //{
            //    Id = 2,
            //    Name = "C63 AMG",
            //    DailyPrice = 70000,
            //    Description = "Updated",
            //    ModelYear = 2021
            //};
            //Console.WriteLine($"Deleting Car: {deletedCar.Name}");
            //carManager.Delete(deletedCar);

            //Console.WriteLine("READ CARS");
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Name);
            //}
        }

        private static void BrandTestCRUD()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("CREATE BRAND");
            brandManager.Add(new Brand()
            {
                Id = 1,
                Name = "BMW"
            }); ;

            Console.WriteLine("READ BRANDS");
            if (brandManager.GetAll().Data.Count > 0)
            {
                foreach (var brand in brandManager.GetAll().Data)
                {
                    Console.WriteLine(brand.Name);
                }
            }
            else
            {
                Console.WriteLine("No Brands");
            }


            Console.WriteLine("UPDATE BRAND");
            Brand updatedBrand = new Brand()
            {
                Id = 1,
                Name = "MERCEDES"

            };
            brandManager.Update(updatedBrand);


            Console.WriteLine("DELETE BRAND");
            Brand deletedBrand = new Brand()
            {
                Id = 1,
                Name = "MERCEDES"
            };
            Console.WriteLine($"Deleting Brand: {deletedBrand.Name}");
            brandManager.Delete(deletedBrand);

            Console.WriteLine("READ CARS");
            if (brandManager.GetAll().Data.Count > 0)
            {
                foreach (var brand in brandManager.GetAll().Data)
                {
                    Console.WriteLine(brand.Name);
                }
            }
            else
            {
                Console.WriteLine("No Brands");
            }
        }
    }
}
