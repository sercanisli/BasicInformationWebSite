using System.Collections.Generic;
using Algan.Business.Abstract;
using Algan.Data.Abstract;
using Algan.Entity;

namespace Algan.Business.Concrete
{
    public class FooterManager : IFooterService
    {
        private IFooterRepository _footerRepository;
        public FooterManager(IFooterRepository footerRepository)
        {
            _footerRepository=footerRepository;
        }
        public void Create(Footer entity)
        {
            _footerRepository.Create(entity);

        }

        public void Delete(Footer entity)
        {
            _footerRepository.Delete(entity);
        }

        public List<Footer> GetAll()
        {
            return _footerRepository.GetAll();
        }

        public Footer GetByID(int id)
        {
            return _footerRepository.GetByID(id);
        }

        public void Update(Footer entity)
        {
            _footerRepository.Update(entity);
        }
    }
}