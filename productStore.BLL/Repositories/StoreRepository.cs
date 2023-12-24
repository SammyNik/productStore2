using productStore.BLL.Models;
using productStore.DAL;
using productStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class StoreRepositoryDb { }; 
namespace productStore.BLL.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly StoreDbContext _dbContext;

        public StoreRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Store GetStoreByCode(int id)
        {
            return _dbContext.Stores.FirstOrDefault(s => s.StoreId == id);
        }

        public void CreateStore(CreateStore store)
        {
            var storeEntity = new Store();
            storeEntity.Name = store.Name;
            storeEntity.Address = store.Address;

            _dbContext.Stores.Add(storeEntity);
            _dbContext.SaveChanges();

        }
        public void DeleteStore(int code)
        {
            var storeToDelete = _dbContext.Stores.FirstOrDefault(s => s.StoreId == code);

            if (storeToDelete != null)
            {
                _dbContext.Stores.Remove(storeToDelete);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Store not found");
            }
        }
    }
}
