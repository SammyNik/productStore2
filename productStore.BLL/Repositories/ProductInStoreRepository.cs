using Microsoft.EntityFrameworkCore;
using productStore.BLL.Models;
using productStore.DAL;
using productStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productStore.BLL.Repositories
{
    public class ProductInStoreRepository : IProductInStoreRepository

    {
        private readonly StoreDbContext _dbContext;

        public ProductInStoreRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateStorewithProducts(CreateProductInStore item)
        {
            var itemEntity = new ProductInStore();
            itemEntity.StoreId = item.StoreId;
            itemEntity.ProductId = item.ProductId;
            itemEntity.Quantity = item.Quantity;
            itemEntity.Price = item.Price;

            _dbContext.ProductInStores.Add(itemEntity);
            _dbContext.SaveChanges();
        }

        public ProductInStore GetProductInStore(int storeId, int productId)
        {
            return _dbContext.ProductInStores
                .Include(x => x.Store)
                .Include(x => x.Product)
                .FirstOrDefault(s => s.StoreId == storeId);
        }

        public string? FindMinCost(int productid)
        {
            decimal minPrice = decimal.MaxValue;
            string cheapestStore = null;
            var productInStore = _dbContext.ProductInStores.Include(x => x.Store);

            foreach (var storeProduct in productInStore)
            {
                if (storeProduct.ProductId == productid)
                {
                    if (storeProduct.Quantity > 0 && (storeProduct.Price < minPrice))
                    {
                        minPrice = storeProduct.Price;
                        cheapestStore = storeProduct.Store.Name;
                    }
                }
            }

            return cheapestStore;
        }


        public void UpdateProductsinStore(UpdateProductInStore update)
        {
            var stockItem = _dbContext.ProductInStores.FirstOrDefault(si => si.StoreId == update.StoreId && si.ProductId == update.ProductId);

            if (stockItem != null)
            {
                stockItem.Quantity = update.Quantity;
                stockItem.Price = update.Price;

                _dbContext.SaveChanges();
            }
        }

        public List<ProductInStore> WhatCanIBuy(int storeId, decimal budget)
        {
            var affordableProducts = new List<ProductInStore>();

            var storeProducts = _dbContext.ProductInStores
                .Where(si => si.StoreId == storeId && si.Quantity > 0)
                .Include(si => si.Product)
                .Include(si => si.Store)
                .ToList();

            foreach (var stockItem in storeProducts)
            {
                int quantityAffordable = (int)(budget / stockItem.Price);

                if (quantityAffordable > 0)
                {
                    var affordableItem = new ProductInStore
                    {
                        StoreId = storeId,
                        Store = stockItem.Store,
                        ProductId = stockItem.ProductId,
                        Product = stockItem.Product,
                        Quantity = quantityAffordable,
                        Price = stockItem.Price
                    };
                    affordableProducts.Add(affordableItem);
                }
            }

            return affordableProducts;
        }

        public decimal BuyItemsInStore(ConsignmentProduct consignment)
        {
            var list = consignment.ProductQuantities;
            decimal resultCost = 0;

            foreach (ProductQuantity item in list)
            {
                var stockItem = _dbContext.ProductInStores.FirstOrDefault(x =>
                    x.StoreId == consignment.StoreCode &&
                    x.Quantity >= item.Quantity &&
                    x.ProductId == item.ProductId);
                if (stockItem == null)
                {
                    throw new Exception("Произошла ошибка при подсчете!");
                }
                resultCost += stockItem.Price * stockItem.Quantity;

            }

            return resultCost;
        }
    }
}
