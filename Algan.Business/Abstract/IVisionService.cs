using System.Collections.Generic;
using Algan.Entity;

namespace Algan.Business.Abstract
{
    public interface IVisionService
    {
        List<Vision> GetAll();
        Vision GetByID (int id);
        void Create (Vision entity);
        void Delete (Vision entity);
        void Update (Vision entity);
    }
}