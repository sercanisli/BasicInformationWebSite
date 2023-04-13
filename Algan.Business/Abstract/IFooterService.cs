using System.Collections.Generic;
using Algan.Entity;

namespace Algan.Business.Abstract
{
    public interface IFooterService
    {
        List<Footer> GetAll();
        Footer GetByID (int id);
        void Create (Footer entity);
        void Delete (Footer entity);
        void Update (Footer entity);
    }
}