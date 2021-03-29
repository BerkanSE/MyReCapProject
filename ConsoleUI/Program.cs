using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    //SOLID prensibleri
    //Open Closed Principle : Yazılımda yeni bir özellik ekliyorsak mevcuttaki kodlara dokunmamak.

    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer
            {
                CompanyName = "Aselsan",
                UserId = 1


            });

            //UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User
            //{
            //  Password="23255",
            //  LastName="Senger",
            //  FirstName="Seren",
            //  Email="sengerseren@gmail.com"

            //});
            //ICarDal InMemoryCarDal'ın referansını tutuyor.

            //Tümünü listele

            // foreach (var car in carManager.GetAll())
            // {
            //     Console.WriteLine(car.Description);
            // }

            //ColorId'sine göre getir

            //foreach (var car in carManager.GetCarsByColorId(2))
            //{
            //    Console.WriteLine(car.ColorId);
            //}

            //CarAddOperation();
            //CarTest();
            //ColorTest();
            //CarDetailsTest();
        }

        private static void CarAddOperation()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                CarId = 4,
                BrandId = 5,
                ColorId = 4,
                ModelYear = 2019,
                DailyPrice = 295,
                Description = "Automatic Car",
                CarName = "Egea"

            });
        }

        //private static void CarDetailsTest()
        //{
        //    CarManager carManager1 = new CarManager(new EfCarDal());
        //    foreach (var car in carManager1.GetCarDetails())
        //    {
        //        Console.WriteLine(car.BrandName + " " + car.CarName);
        //    }
        //}



        //private static void ColorTest()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    foreach (var color in colorManager.GetAll())
        //    {
        //        Console.WriteLine(color.ColorName);
        //    }
        //}

        //private static void CarTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetAll())
        //    {
        //        Console.WriteLine(car.CarName + " " + car.DailyPrice);
        //    }
        //}
    }
}
