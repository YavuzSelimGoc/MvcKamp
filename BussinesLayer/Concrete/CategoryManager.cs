﻿using DataAccesLayer.Concrete.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repository = new GenericRepository<Category>();
        public List<Category> GetAllBl()
        {
            return repository.List();
        }
        public void CategoryAddBl(Category category)
        {
            if (category.CategoryName == ""  || category.CategoryName.Length<=3 || category.CategoryDescription==""
                || category.CategoryName.Length>50)
            {
                //hata mesajı
            }
            else
            {
                repository.Insert(category);
            }
        }
    }
}
