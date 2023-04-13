using System.Collections.Generic;
using Algan.Business.Abstract;
using Algan.Data.Abstract;
using Algan.Entity;

namespace Algan.Business.Concrete 
{
    public class PersonManager : IPersonService
    {
        private IPersonRepository _personRepository;
        public PersonManager(IPersonRepository personRepository)
        {
            _personRepository=personRepository;
        }
        public void Create(Person entity)
        {
            _personRepository.Create(entity);
        }

        public void Delete(Person entity)
        {
            _personRepository.Delete(entity);
        }

        public List<Person> GetAll()
        {
            return _personRepository.GetAll();
        }

        public Person GetByID(int id)
        {
            return _personRepository.GetByID(id);
        }

        public void Update(Person entity)
        {
            _personRepository.Update(entity);
        }
    }
}