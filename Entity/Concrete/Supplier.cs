﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Supplier: BaseEntity
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
    }
}
