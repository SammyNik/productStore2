using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace productStore.DAL.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [JsonIgnore]
        public ICollection<ProductInStore>? ProductInStores { get; set; }
    }
}
