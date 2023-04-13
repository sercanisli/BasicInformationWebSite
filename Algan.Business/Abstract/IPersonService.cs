using System.Collections.Generic;
using Algan.Entity;


namespace Algan.Business.Abstract
{
    public interface IPersonService
    { 
        List<Person> GetAll();
        Person GetByID (int id);
        void Create (Person entity);
        void Delete (Person entity);
        void Update (Person entity);
    }
}