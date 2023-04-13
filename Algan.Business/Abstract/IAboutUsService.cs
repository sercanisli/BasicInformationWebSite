using System.Collections.Generic;
using Algan.Entity;

namespace Algan.Business.Abstract
{
    public interface IAboutUsService
    {
        List<AboutUs> GetAll();
        AboutUs GetByID (int id);
        void Create (AboutUs entity);
        void Delete (AboutUs entity);
        void Update (AboutUs entity);
    }
}