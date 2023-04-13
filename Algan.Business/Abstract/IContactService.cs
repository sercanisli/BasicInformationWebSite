using System.Collections.Generic;
using Algan.Entity;

namespace Algan.Business.Abstract
{
    public interface IContactService
    {
        List<Contact> GetAll();
        Contact GetByID (int id);
        void Create (Contact entity);
        void Delete (Contact entity);
        void Update (Contact entity);
    }
}