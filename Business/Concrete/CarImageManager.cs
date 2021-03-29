using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage,IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(carImage));
           
            if(result != null)
            {
                return result;
            }
            
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        private IResult CheckCarImageLimit(CarImage carImage)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carImage.CarId).Count;
            if (result >= 2)
            {
                return new ErrorResult(Messages.CarImageLimited);
            }
            return new SuccessResult();
            //Business kurallarında success'e mesaj yazmaya gerek duyulmaz.

        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.CarImageId == carImageId));
        }

        public IDataResult<List<CarImage>> GetImageByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarPhotoIsNull(carId));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }
            return new SuccessDataResult<List<CarImage>>(CheckIfCarPhotoIsNull(carId).Data);
        }

        private IDataResult<List<CarImage>> CheckIfCarPhotoIsNull(int carId)
        {
            
            try
            {
                //Eğer bir arabaya ait resim yoksa, default bir path vereceğiz.
                string path = @"\CarImages\carLogo.jpg";

                var result = _carImageDal.GetAll(ci => ci.CarId == carId).Any();

                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>();
                    //return new List<CarImage> { new CarImage() { CarId = carId, Date = DateTime.Now, ImagePath = path } };
                    carImage.Add(new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return  new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));



        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfMaxPhotoLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(ci => ci.CarImageId == carImage.CarImageId).ImagePath ;
            carImage.ImagePath = FileHelper.Update(oldPath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult("İşlem başarılı");
        }

        private IResult CheckIfMaxPhotoLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);

            if (result.Count < 5)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
