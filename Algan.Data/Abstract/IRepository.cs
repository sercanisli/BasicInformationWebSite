using System.Collections.Generic;

namespace Algan.Data.Abstract
{
    public interface IRepository<T> 
    {
        List<T> GetAll();
        T GetByID(int id);

        void Create(T entity);
      
        void Update(T entity);
        
        void Delete(T entity);
    }
}