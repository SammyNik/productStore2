using Microsoft.AspNetCore.Mvc;
using productStore.BLL.Models;
using productStore.BLL.Repositories;
using productStore.DAL.Models;

namespace productStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductInStoreController : ControllerBase
    {
        private readonly IProductInStoreRepository _productInStoreRepository;
        public static List<ProductInStore> ProductInStores = new List<ProductInStore> { };

        public ProductInStoreController(IProductInStoreRepository productInStoreRepository)
        {
            _productInStoreRepository = productInStoreRepository;
        }

        [HttpGet]
        public ProductInStore Get(int storeId, int productId)
        {
            var item = _productInStoreRepository.GetProductInStore(storeId, productId);
            return item;
        }

        [HttpPut]
        public IActionResult Put(UpdateProductInStore update)
        {
            _productInStoreRepository.UpdateProductsinStore(update);
            return Ok();
        }

        [HttpGet("MinCost")]
        public IActionResult FindMinCost(int productId)
        {
            string cheapestStore = _productInStoreRepository.FindMinCost(productId);

            if (cheapestStore == null)
            {
                return NotFound();
            }

            return Ok(cheapestStore);
        }

        /// <summary>
        /// метод завезти партию продуктов в магазин
        /// </summary>
        /// <param name="body"></param>
        /// 
        [HttpPost("")]
        public ActionResult Create(CreateProductInStore stockitem)
        {
            _productInStoreRepository.CreateStorewithProducts(stockitem);
            return Ok();
        }

        [HttpGet("WhatCanIBuy")]
        public IActionResult WhatCanIBuy(int storeId, decimal budget)
        {
            var affordableProducts = _productInStoreRepository.WhatCanIBuy(storeId, budget);
            return Ok(affordableProducts);
        }

        [HttpPost("m")]
        public IActionResult BuyItemsInStore(ConsignmentProduct consignment)
        {
            var price = _productInStoreRepository.BuyItemsInStore(consignment);
            return Ok(price);
        }
    }
}
