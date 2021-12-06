using BussinesLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

       

        public void CategoryAddBl(Category category)
        {
            
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetById(int Id)
        {
            return _categoryDal.Get(x => x.CategoryID == Id);
        }

        //GenericRepository<Category> repository = new GenericRepository<Category>();
        //public List<Category> GetAllBl()
        //{
        //    return repository.List();
        //}
        //public void CategoryAddBl(Category category)
        //{

        //    if (category.CategoryName == "" || category.CategoryName.Length <= 3 || category.CategoryDescription == ""
        //        || category.CategoryName.Length > 50)
        //    {
        //        //hata mesajı
        //    }
        //    else
        //    {
        //        repository.Insert(category);
        //    }
        //}
        public List<Category> GetList()
        {
            return _categoryDal.List();
        }
       
    }
}
