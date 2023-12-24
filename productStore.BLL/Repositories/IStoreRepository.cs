using productStore.BLL.Models;
using productStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productStore.BLL.Repositories
{
    public interface IStoreRepository
    {
        Store GetStoreByCode(int id);
        void CreateStore(CreateStore store);
        void DeleteStore(int code);
    }
}
