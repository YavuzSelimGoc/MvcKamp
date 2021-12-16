using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> GetList();
        void ImageFileAddBl(ImageFile imageFile);
        ImageFile GetById(int Id);
        void ImageFileDelete(ImageFile imageFile);
        void ImageFileUpdate(ImageFile imageFile);
    }
}
