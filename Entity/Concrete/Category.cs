﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
