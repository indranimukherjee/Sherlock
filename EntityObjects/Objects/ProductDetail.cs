using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObjects.Objects
{
   public class ProductDetail : BaseEntity
    {
        public string product_name { get; set; }
        public int parent_product_id { get; set; }
        public bool product_deleted { get; set; }


    }
}
