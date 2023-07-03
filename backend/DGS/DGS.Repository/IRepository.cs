using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.Repository
{
    public interface IRepository<T, H, K> where T : class where H : class 
    {
        Task<List<T>> GetAll();
        Task<T> FindById(K id);
        Task Add(H entity);
        Task Update(H entity);
        Task Remove(K id);

    }
}
