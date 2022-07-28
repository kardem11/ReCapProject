using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarNameExists(carImage.CarId), CheckIfCarNameExists (carImage.ImagePath));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Upload(file, PathConstans.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("Upload successful");
        }

        private IResult CheckIfCarNameExists(string ımagePath)
        {
            var result = _carImageDal.GetAll();
            if (result.Count > 1)
            {
                return new ErrorResult(Messages.CarImageUpdated);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarNameExists(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result <=3)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            return new SuccessResult();
        }    


        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstans.ImagesPath + carImage.ImagePath);
            _carImageDal.Remove(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarNameExists(carId));
            {
                if (result != null)
                {
                    return new ErrorDataResult<List<CarImage>>(GetByCarId(carId).Data);
                }
                return new SuccessDataResult<List<CarImage>>();
            }
        }


        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=> c.Id==imageId));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstans.ImagesPath + carImage.ImagePath, PathConstans.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
    }
}
