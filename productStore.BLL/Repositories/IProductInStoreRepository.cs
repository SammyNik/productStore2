using productStore.BLL.Models;
using productStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productStore.BLL.Repositories
{
    public interface IProductInStoreRepository
    {
        void CreateStorewithProducts(CreateProductInStore item);
        ProductInStore GetProductInStore(int storeId, int productId);
        void UpdateProductsinStore(UpdateProductInStore update);
        string FindMinCost(int productid);
        List<ProductInStore> WhatCanIBuy(int storeId, decimal budget);
        decimal BuyItemsInStore(ConsignmentProduct consignment);
    }
}
