using BussinesLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _ImageFileDal;
        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _ImageFileDal = imageFileDal;
        }
        public ImageFile GetById(int Id)
        {
            return _ImageFileDal.Get(x=>x.ImageId==Id);
        }

        public List<ImageFile> GetList()
        {
            return _ImageFileDal.List();
        }

        public void ImageFileAddBl(ImageFile imageFile)
        {
            _ImageFileDal.Insert(imageFile);
        }

        public void ImageFileDelete(ImageFile imageFile)
        {
            _ImageFileDal.Delete(imageFile);
        }

        public void ImageFileUpdate(ImageFile imageFile)
        {
            _ImageFileDal.Update(imageFile);
        }
    }
}
