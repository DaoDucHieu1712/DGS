﻿using DGS.BusinessObjects;
using DGS.BusinessObjects.Entities;
using DGS.DataAccess.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.DataAccess.impls
{
    public class CategoryDAO : EntityDAO<Category, int>, ICategoryDAO
    {
        public CategoryDAO(ApplicationDbContext context) : base(context)
        {
        }
    }
}
