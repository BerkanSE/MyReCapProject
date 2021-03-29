using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car> //Çalışma tipi : "Car"
    {
        //Interface metotları default public'tir.
        //IEntityRepository'e taşırız.
        //[Generic Altyapı]
        List<CarDetailDto> GetCarDetails();
        

    }
}
