using System.Collections.Generic;
using Algan.Entity;

namespace Algan.Business.Abstract
{
    public interface IStreamService
    {
        List<Stream> GetAll();
        Stream GetByID (int id);
        void Create (Stream entity);
        void Update (Stream entity);
        void Delete (Stream entity);
    }
}