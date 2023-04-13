using System.Collections.Generic;
using Algan.Business.Abstract;
using Algan.Data.Abstract;
using Algan.Entity;

namespace Algan.Business.Concrete
{
    public class ContactManager : IContactService
    {
        private IContactRepository _contactRepository;
        public ContactManager(IContactRepository contactRepository)
        {
            _contactRepository=contactRepository;
        }
        public void Create(Contact entity)
        {
            _contactRepository.Create(entity);
        }

        public void Delete(Contact entity)
        {
            _contactRepository.Delete(entity);
        }

        public List<Contact> GetAll()
        {
            return _contactRepository.GetAll();
        }

        public Contact GetByID(int id)
        {
            return _contactRepository.GetByID(id);
        }

        public void Update(Contact entity)
        {
            _contactRepository.Update(entity);
        }
    }
}