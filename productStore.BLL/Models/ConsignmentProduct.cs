using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productStore.BLL.Models
{
    public class ConsignmentProduct
    {
        public List<ProductQuantity> ProductQuantities { get; set; }
        public int StoreCode { get; set; }
    }
}
