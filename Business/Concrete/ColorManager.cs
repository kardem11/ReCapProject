﻿using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        public List<Color> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Color> GetCarsByColorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
