using System.Collections.Generic;
using Algan.Entity;

namespace Algan.Business.Abstract
{
    public interface IMissionService
    { 
        List<Mission> GetAll();
        Mission GetByID (int id);
        void Create (Mission entity);
        void Delete (Mission entity);
        void Update (Mission entity);
    }
}