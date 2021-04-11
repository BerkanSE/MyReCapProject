using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car> //Çalışma tipi : "Car"
    {
        //Interface metotları default public'tir.
        //IEntityRepository'e taşırız.
        //[Generic Altyapı]
        List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null);
        List<CarDetailDto> GetCarDetailsByBrandAndColorId(Expression<Func<CarDetailDto, bool>> filter);

        //List<CarDetailDto> GetCarDetailsByBrandId(Expression<Func<Car, bool>> filter);

        //List<CarDetailDto> GetCarDetailsByColorId(Expression<Func<Car, bool>> filter);

    }
}
