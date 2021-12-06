﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        void WriterAddBl(Writer writer);
        Writer GetById(int Id);
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
    }
}
