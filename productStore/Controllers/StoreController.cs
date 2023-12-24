using Microsoft.AspNetCore.Mvc;
using productStore.BLL.Models;
using productStore.BLL.Repositories;
using productStore.DAL.Models;

namespace productStore.Controllers
{
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;
        public static List<Store> Stores = new List<Store> { };


        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        /// <summary>
        ///  метод получения магазина по идентификатору
        /// </summary>
        /// <param name="id">Наименование магазина</param>

        [HttpGet("Searching Store")]
        public Store Get(int storeCode)
        {
            var store = _storeRepository.GetStoreByCode(storeCode);
            return store;
        }

        /// <summary>
        ///  метод получения информации о всех продуктах
        /// </summary>
        /// <param name="id">Идентификатор продукта</param>
        [HttpGet]
        public List<Store> GetAll() => Stores;

        /// <summary>
        /// метод создания магазина продуктов
        /// </summary>
        /// <param name="body"></param>

        [HttpPost("Creating Store")]
        public ActionResult Create(CreateStore store)
        {
            _storeRepository.CreateStore(store);
            return Ok();
        }

        /// <summary>
        /// метод удаления продукта по идентификатору
        /// </summary>
        /// <param name="cosmeticId">Идентификатор продукта</param>

        [HttpDelete("Deleting Store")]
        public void Delete(int ID) => Stores.RemoveAt(ID);
    }
}
