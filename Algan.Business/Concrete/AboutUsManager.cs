using System.Collections.Generic;
using Algan.Business.Abstract;
using Algan.Data.Abstract;
using Algan.Entity;

namespace Algan.Business.Concrete
{
    public class AboutUsManager : IAboutUsService
    {
        private IAboutUsRepository _aboutUsRepository;
        public AboutUsManager(IAboutUsRepository aboutUsRepository)
        {
            _aboutUsRepository=aboutUsRepository;
        }
        public void Create(AboutUs entity)
        {
            _aboutUsRepository.Create(entity);
        }

        public void Delete(AboutUs entity)
        {
            _aboutUsRepository.Delete(entity);
        }

        public List<AboutUs> GetAll()
        {
            return _aboutUsRepository.GetAll();
        }

        public AboutUs GetByID(int id)
        {
            return _aboutUsRepository.GetByID(id);
        }

        public void Update(AboutUs entity)
        {
            _aboutUsRepository.Update(entity);
        }
    }
}