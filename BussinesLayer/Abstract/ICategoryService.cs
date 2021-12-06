﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        void CategoryAddBl(Category category);
        Category GetById(int Id);
        void CategoryDelete(Category category);
        void CategoryUpdate(Category category);
    }
}