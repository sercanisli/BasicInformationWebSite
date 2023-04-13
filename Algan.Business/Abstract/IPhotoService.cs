using System.Collections.Generic;
using Algan.Entity;

namespace Algan.Business.Abstract
{
    public interface IPhotoService
    {
        List<Photo> GetAll();
        Photo GetByID (int id);

        void Create (Photo entity);
        void Delete (Photo entity);
        void Update (Photo entity);
    }
}