using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Order: BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        //public virtual Product ProductName { get; set; }

    }
}
