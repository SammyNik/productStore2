using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productStore.DAL.Models
{
    public class ProductInStore
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
