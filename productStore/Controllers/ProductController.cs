using Microsoft.AspNetCore.Mvc;
using productStore.BLL.Models;
using productStore.BLL.Repositories;
using productStore.DAL.Models;

namespace productStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public static List<Product> Products = new List<Product> { };
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        ///  метод получения продукта по идентификатору
        /// </summary>
        /// <param name="id">Наименование продукта</param>

        [HttpGet("{id:int}")]
        public Product Get(int id)
        {
            var product = _productRepository.GetProductById(id);
            return product;
        }

        /// <summary>
        /// метод создания продуктов
        /// </summary>
        /// <param name="body"></param>

        [HttpPost("CreatingProduct")]
        public ActionResult Create(CreateProduct product)
        {
            _productRepository.CreateProduct(product);
            return Ok();
        }

        /// <summary>
        /// метод удаления продукта по идентификатору
        /// </summary>
        /// <param name="cosmeticId">Идентификатор продукта</param>


        [HttpDelete("Deleting Product")]
        public void Delete(int ID) => Products.RemoveAt(ID);

    }
}
